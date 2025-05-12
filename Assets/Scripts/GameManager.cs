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
    public float totalTime = 0;   // ������ �÷����� �ð�

    public bool isUIClosed;     // UI �г��� ��� ���� �÷��� ȭ������ üũ

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

    // ���� �ʱ�ȭ
    private void Init()
    {
        currentStageNum = SceneManager.GetActiveScene().buildIndex;
        stageCatCount = 0;
        totalCatCount = 0;
        isUIClosed = true;
    }

    // �� ��ȯ �� stageNum�� stageCatCount �� �ʱ�ȭ
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        isUIClosed = true;
        currentStageNum = SceneManager.GetActiveScene().buildIndex;
        stageCatCount = 0;
    }

    // ����̸� ã�� �� ã�� ����� ���� ǥ���ϴ� text UI ������Ʈ
    public void UpdateFoundCatInfo()
    {
        stageCatCount++;
        totalCatCount++;
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
