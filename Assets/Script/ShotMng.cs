using UnityEngine;

public class ShotMng : MonoBehaviour
{

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5f);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }



        if (collision.gameObject.CompareTag("Enemy1"))
        {
            StatsInfo.Enm1_HP -= 1 ;
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("EnemyA"))
        {
            //StatsInfo.EnemyA_HP -= 1 ;
            Destroy(gameObject,0.05f);
        }
    }


}
