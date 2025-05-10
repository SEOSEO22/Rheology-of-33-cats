using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentStageNum; // ���� ��������
    public int stageCatCount;   // ���� ������������ ã�� ����� ��
    public int totalCatCount;   // ��ü ������������ ã�� ����� ��
    public int[] catNumToFind   // �� ������������ ã�ƾ� �� ����� ��
        = { 1, 2, 5, 5, 10, 10 };

    public bool isUIClosed;     // UI �г��� ��� ���� �÷��� ȭ������ üũ

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

    // ���� �ʱ�ȭ
    private void Init()
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex + 1;
        currentStageNum = 0;
        totalCatCount = 0;
        isUIClosed = true;
    }

    // �� ��ȯ �� stageNum�� stageCatCount �� �ʱ�ȭ
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageCatCount = 0;
    }

    // ����̸� ã�� �� ã�� ����� ���� ǥ���ϴ� text UI ������Ʈ
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;

        // UI text�� ������Ʈ�ϴ� �ڵ� �߰�
    }

    public bool GameOver()
    {
        // ����̸� �� ã�� ���ߴٸ�
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
