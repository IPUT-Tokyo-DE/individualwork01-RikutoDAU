using UnityEngine;
using System.Collections;
public class PlayerShoot : MonoBehaviour
{
    public GameObject shotPrefab;
    public GameObject mpShotPrefab;
    //public float shotSpeed = 2f;

    private float shotSpeed = 20f;

    private bool shotting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && shotting == false )
        {
            StartCoroutine(Shoot());
        }

        if (MpStats.mp == 30)
        {
            if (Input.GetKeyDown(KeyCode.Mouse1))
            {
                MpShoot();
            }
        }


    }

    IEnumerator Shoot()
    {
        shotting = true;
        while (Input.GetKey(KeyCode.Mouse0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            Vector2 direction = (mousePos - transform.position).normalized;

            GameObject shot = Instantiate(shotPrefab, transform.position, Quaternion.identity);


            Rigidbody2D rb = shot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * shotSpeed;

            yield return new WaitForSeconds(0.3f);
        }
        shotting =false;
    }

    void MpShoot()
    {
        MpStats.mp = 0;

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        //Vector3 midPotision = (mousePos + transform.position) / 2;

        Vector2 direction = (mousePos - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        GameObject mpShot = Instantiate(mpShotPrefab, transform.position, rotation);


        Destroy(mpShot,2f);
        /*
        Rigidbody2D rb = mpShot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * shotSpeed /2 ;
        */
        

    }
}
