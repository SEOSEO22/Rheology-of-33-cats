using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScript : MonoBehaviour
{
    public Text startText;
    public Text latestRecordText;

    private Color originColor;
    private Color changedColor;
    private float blinkTime = 1f;

    private void Start()
    {
        originColor = startText.color;
        changedColor = new Color(startText.color.r, startText.color.g, startText.color.b, 0);

        int min = (int)GameManager.Instance.latestTimeRecord / 60;
        float sec = GameManager.Instance.latestTimeRecord % 60;
        int stage = GameManager.Instance.latestStageRecord;

        latestRecordText.text = $"직전 기록 : {stage}단계 {min}분 {sec:F3}초";

        StartCoroutine(ChangeColor());
    }

    public void OnStartBtnClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    IEnumerator ChangeColor()
    {
        float currentTime = 0f;

        while (currentTime < blinkTime)
        {
            currentTime += Time.deltaTime;
            startText.color = Color.Lerp(originColor, changedColor, currentTime);

            yield return null;
        }

        StartCoroutine(ReturnColor());
    }

    IEnumerator ReturnColor()
    {
        float currentTime = 0f;

        while (currentTime < blinkTime)
        {
            currentTime += Time.deltaTime;
            startText.color = Color.Lerp(changedColor, originColor, currentTime);

            yield return null;
        }

        StartCoroutine(ChangeColor());
    }
}
