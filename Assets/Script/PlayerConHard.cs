using UnityEngine;

public class PlayerConHard : MonoBehaviour
{

    private float speed = 5f;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0f;
        //Vector3 midPotision = (mousePos + transform.position) / 2;

        Vector2 direction = (mousePos - transform.position).normalized;

        Quaternion rotation = Quaternion.LookRotation(Vector3.forward, direction);

        rb.transform.rotation = rotation;
        


        if (StatsInfo.PlayerHP <= 0)
        {
            Destroy(this.gameObject);
        }

        if (Input.GetKey(KeyCode.W))    //ã‚ÉˆÚ“®
        {
            this.transform.position += transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S))    //‰º‚ÉˆÚ“®
        {
            this.transform.position += -transform.up * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))   //¶‚ÉˆÚ“®
        {
            this.transform.position += -transform.right * speed * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D))    //‰E‚ÉˆÚ“®
        {
            this.transform.position += transform.right * speed * Time.deltaTime;
        }

    }

}