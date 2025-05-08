using UnityEngine;

public class ClickCats : MonoBehaviour
{
    private void Update()
    {
        HandleInput();
    }

    // ��ġ/Ű���� �Է� �� �̹����� ���������� ����
    private void HandleInput()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 worldPoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(worldPoint, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                GetComponent<SpriteRenderer>().color = Color.red;
            }

            GameManager.Instance.UpdateFoundCatInfo();
        }
    }
}
