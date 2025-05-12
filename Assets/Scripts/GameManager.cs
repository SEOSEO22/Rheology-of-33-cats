using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentStageNum; // 현재 스테이지
    public int stageCatCount;   // 현재 스테이지에서 찾은 고양이 수
    public int totalCatCount;   // 전체 스테이지에서 찾은 고양이 수
    public int[] catNumToFind   // 각 스테이지에서 찾아야 할 고양이 수
        = { 1, 2, 5, 5, 10, 10 };
    public float totalTime = 0;   // 게임을 플레이한 시간

    public bool isUIClosed;     // UI 패널이 모두 닫힌 플레이 화면인지 체크

    private void Awake()
    {
        #region Singleton
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        #endregion

        Init();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 변수 초기화
    private void Init()
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex;
        stageCatCount = 0;
        totalCatCount = 0;
        isUIClosed = true;
    }

    // 씬 전환 시 stageNum과 stageCatCount 값 초기화
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isUIClosed = true;
        currentStageNum = SceneManager.GetActiveScene().buildIndex;
        stageCatCount = 0;
    }

    // 고양이를 찾을 시 찾은 고양이 수를 표기하는 text UI 업데이트
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;
    }

    // 해상도 설정하는 함수
    public void SetResolution()
    {
        int setWidth = 1920; // 사용자 설정 너비
        int setHeight = 1080; // 사용자 설정 높이

        int deviceWidth = Screen.width; // 기기 너비 저장
        int deviceHeight = Screen.height; // 기기 높이 저장

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution 함수 제대로 사용하기
        Camera.main.backgroundColor = Color.black; // 카메라 배경색을 검정색으로 설정

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // 기기의 해상도 비가 더 큰 경우
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // 새로운 너비
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // 새로운 Rect 적용
        }
        else // 게임의 해상도 비가 더 큰 경우
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // 새로운 높이
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // 새로운 Rect 적용
        }
    }

    public bool GameOver()
    {
        // 고양이를 다 찾지 못했다면
        if (stageCatCount < catNumToFind[currentStageNum - 1])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
