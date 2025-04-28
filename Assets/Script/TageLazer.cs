using UnityEngine;
using System.Collections;
public class TageLazer : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject LazerObPrefab;

    public GameObject LazerOb2Prefab;

    public GameObject LazerSignPrefab;
    private float LazerSpeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyCon.ranAtk == 6)
        {
            StartCoroutine (tageLazer());
        }
    }


    IEnumerator tageLazer()
    {
        EnemyCon.ranAtk = 0;

        yield return new WaitForSeconds(1f);

        for (int i = 0; i < 3; ++i) //ƒŒ[ƒU‚Ì‹O“¹Œx‚ð3‰ño‚·
        {
            /*
            Vector3 enmPosSign = this.gameObject.transform.position;
            Vector2 directionSign = (playerTransform.position - enmPosSign).normalized;

            */
            GameObject LazerSign = Instantiate(LazerSignPrefab, transform.position, Quaternion.identity);

            /*
            float angleSign = Mathf.Atan2(directionSign.y, directionSign.x) * Mathf.Rad2Deg;    //Šp“x‚ð’²®
            LazerSign.transform.rotation = Quaternion.Euler(0, 0, angleSign + 0);
            */
            yield return new WaitForSeconds(0.1f);
            Destroy(LazerSign);
            yield return new WaitForSeconds(0.1f);
        }

        Vector3 enmPos = this.gameObject.transform.position;
        Vector2 direction = (playerTransform.position - enmPos).normalized;

        yield return new WaitForSeconds(0.4f);

        GameObject LazerOb = Instantiate(LazerObPrefab, enmPos, Quaternion.identity);

        GameObject LazerOb2 = Instantiate(LazerOb2Prefab, enmPos, Quaternion.identity);

        LazerOb.transform.rotation = Quaternion.Euler(0, 0, 0);
        LazerOb2.transform.rotation = Quaternion.Euler(0, 0,  90);
        Rigidbody2D rb = LazerOb.GetComponent<Rigidbody2D>();
        Rigidbody2D rb2 = LazerOb2.GetComponent<Rigidbody2D>();

        rb.linearVelocity = direction * 100f;
        yield return new WaitForSeconds(1f);
        Destroy(LazerOb);
        Destroy(LazerOb2);

    }
}
