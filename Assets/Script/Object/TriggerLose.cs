using UnityEngine;

public class TriggerLose : MonoBehaviour
{
    private float timer = 0f;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            timer += Time.deltaTime;
            if (timer > GameManager.instance.TimeTillGameOver)
            {
                GameManager.instance.GameOver();
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            timer = 0f;
        }
    }
}
