using UnityEngine;

public class SurrondShots : MonoBehaviour
{
    public Transform playerTransform;
    public GameObject surShotPrefabs;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SurShot();
    }

    // Update is called once per frame
    void Update()
    {



    }

    void SurShot()
    {
        Vector3 ShotPos = this.gameObject.transform.position;

        Vector2 direction = (playerTransform.position - ShotPos).normalized;

        GameObject surroundShot = Instantiate(surShotPrefabs, transform.position, Quaternion.identity);

        Rigidbody2D rb = surroundShot.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * 1f;

        
    }
}
