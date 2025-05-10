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

    // �ػ� �����ϴ� �Լ�
    public void SetResolution()
    {
        int setWidth = 1920; // ����� ���� �ʺ�
        int setHeight = 1080; // ����� ���� ����

        int deviceWidth = Screen.width; // ��� �ʺ� ����
        int deviceHeight = Screen.height; // ��� ���� ����

        Screen.SetResolution(setWidth, (int)(((float)deviceHeight / deviceWidth) * setWidth), true); // SetResolution �Լ� ����� ����ϱ�
        Camera.main.backgroundColor = Color.black; // ī�޶� ������ ���������� ����

        if ((float)setWidth / setHeight < (float)deviceWidth / deviceHeight) // ����� �ػ� �� �� ū ���
        {
            float newWidth = ((float)setWidth / setHeight) / ((float)deviceWidth / deviceHeight); // ���ο� �ʺ�
            Camera.main.rect = new Rect((1f - newWidth) / 2f, 0f, newWidth, 1f); // ���ο� Rect ����
        }
        else // ������ �ػ� �� �� ū ���
        {
            float newHeight = ((float)deviceWidth / deviceHeight) / ((float)setWidth / setHeight); // ���ο� ����
            Camera.main.rect = new Rect(0f, (1f - newHeight) / 2f, 1f, newHeight); // ���ο� Rect ����
        }
    }

    //Test
    private void Update()
    {
        LoadNextStage();
    }

    //Test
    public void LoadNextStage()
    {
        // ���� ������������ ã�ƾ��� ����̸� ��� ã��
        if (stageCatCount == catNumToFind[currentStageNum - 1])
        {
            // ���� ���� �������� 6�� �ƴ϶��
            if (SceneManager.GetActiveScene().name != "Stage 6")
            {
                // ���� �������� �ε�
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    public bool GameOver()
    {
        // ����̸� �� ã�� ���ߴٸ�
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
