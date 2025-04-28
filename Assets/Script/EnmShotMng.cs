using UnityEngine;

public class EnmShotMng : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject,10f);

        if (StatsInfo.Enm1_HP <= 0)
        {
            Destroy(gameObject);
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
            StatsInfo.PlayerHP -= 10;

            Destroy(this.gameObject);
        }

        if (collision.gameObject.CompareTag("PlayerMpShot"))
        {
            Destroy(this.gameObject);
        }
    }   
}
