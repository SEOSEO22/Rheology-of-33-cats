using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNum;        // 현재 스테이지
    public int stageCatCount;   // 현재 스테이지에서 찾은 고양이 수
    public int totalCatCount;   // 전체 스테이지에서 찾은 고양이 수
    public int[] catNumToFind  // 각 스테이지에서 찾아야 할 고양이 수
        = { 1, 2, 5, 5, 10, 10 };

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
    }

    private void Start()
    {
        Init();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    // 변수 초기화
    private void Init()
    {
        stageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageNum = 0;
        totalCatCount = 0;
    }

    // 씬 전환 시 stageNum과 stageCatCount 값 초기화
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        stageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageCatCount = 0;
    }

    // 고양이를 찾을 시 찾은 고양이 수를 표기하는 text UI 업데이트
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;

        // UI text를 업데이트하는 코드 추가
    }
}
