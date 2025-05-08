using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int stageNum;        // ���� ��������
    public int stageCatCount;   // ���� ������������ ã�� ����� ��
    public int totalCatCount;   // ��ü ������������ ã�� ����� ��
    public int[] catNumToFind  // �� ������������ ã�ƾ� �� ����� ��
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

    // ���� �ʱ�ȭ
    private void Init()
    {
        stageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageNum = 0;
        totalCatCount = 0;
    }

    // �� ��ȯ �� stageNum�� stageCatCount �� �ʱ�ȭ
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        stageNum = SceneManager.GetActiveScene().buildIndex + 1;
        stageCatCount = 0;
    }

    // ����̸� ã�� �� ã�� ����� ���� ǥ���ϴ� text UI ������Ʈ
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;

        // UI text�� ������Ʈ�ϴ� �ڵ� �߰�
    }
}
