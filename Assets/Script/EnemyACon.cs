using UnityEngine;
using System.Collections;

public class EnemyACon : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject enmShotPrefabs;

    private int shotNum = 5;
    private float spreadAngle = 120f;
    private float enmShotSpeed = 5f;

    private int EnemyAHP = 2;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(enmASpw());
    }

    // Update is called once per frame
    void Update()
    {

        Debug.Log("EnemyA_" + EnemyAHP);


    }

    IEnumerator enmASpw()
    {
        EnemyCon.ranAtk = 0;


        while (EnemyAHP > 0)
        {
            for (int j = 0; j < 5; j++)
            {
                Vector3 enmPos = this.transform.position;

                Vector3 direction = (playerTransform.position - enmPos).normalized;

                float baseAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

                for (int i = 0; i < shotNum; ++i)
                {
                    GameObject enmAShot = Instantiate(enmShotPrefabs, transform.position, Quaternion.identity);
                    Rigidbody2D rb = enmAShot.GetComponent<Rigidbody2D>();

                    float angleOffset = spreadAngle / (shotNum - 1) * i - spreadAngle / 2;
                    float shotAngle = baseAngle + angleOffset;

                    enmAShot.transform.rotation = Quaternion.Euler(0, 0, shotAngle);

                    Vector3 shotDirection = new Vector3(Mathf.Cos(shotAngle * Mathf.Deg2Rad), Mathf.Sin(shotAngle * Mathf.Deg2Rad), 0);

                    rb.AddForce(shotDirection * enmShotSpeed, ForceMode2D.Impulse);

                    //yield return new WaitForSeconds(0.1f);
                }
                yield return new WaitForSeconds(0.5f);
            }

            yield return new WaitForSeconds(1f);
        }

        yield break;
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            EnemyAHP -= 1;


            if (EnemyAHP <= 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
