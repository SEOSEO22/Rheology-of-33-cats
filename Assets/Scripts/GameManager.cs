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

    public bool isUIClosed;     // UI 패널이 모두 닫힌 플레이 화면인지 체크

    private void Awake()
    {
        #region Singleton
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
        else
        {
            Destroy(this.gameObject);
        }
        #endregion

        Init();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 변수 초기화
    private void Init()
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex + 1;
        currentStageNum = 0;
        totalCatCount = 0;
        isUIClosed = true;
    }

    // 씬 전환 시 stageNum과 stageCatCount 값 초기화
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageCatCount = 0;
    }

    // 고양이를 찾을 시 찾은 고양이 수를 표기하는 text UI 업데이트
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;

        // UI text를 업데이트하는 코드 추가
    }

    public bool GameOver()
    {
        // 고양이를 다 찾지 못했다면
        if (stageCatCount < catNumToFind[currentStageNum])
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
