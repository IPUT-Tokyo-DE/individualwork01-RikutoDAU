using UnityEngine;

public class EnmLaserMng : MonoBehaviour
{
    private bool hitting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hitting = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (hitting == true)
        {
            StatsInfo.PlayerHP -= 1f;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("Player"))
        {
            hitting = true;

        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hitting = false;

        }
    }
}
