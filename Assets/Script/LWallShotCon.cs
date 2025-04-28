using UnityEngine;
using System.Collections;

public class LWallShotCon : MonoBehaviour
{
    public Transform playerTransform;

    public GameObject enmWalLShotPrefab;
    private float wallShotSpeed = 5f;

    private float minX = -15;
    private float maxX = -15;
    private float minY = -20;   //�ړ��͈�
    private float maxY = 20;

    //private bool wallShoting;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(wallShot());
        StartCoroutine(wallSouceTP());
    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (StatsInfo.Enm1_HP < 100 && !wallShoting)
        {
            wallShoting = true;
            StartCoroutine(wallShot());
            StartCoroutine(wallSouceTP());
        }
        */


    }

    IEnumerator wallShot()
    {



        while (StatsInfo.Enm1_HP > 0)
        {
            {
                

                Vector3 rSidePos = this.gameObject.transform.position;

                Vector2 direction = (playerTransform.position - rSidePos).normalized;

                GameObject wallShot = Instantiate(enmWalLShotPrefab, transform.position, Quaternion.identity);

                float wallShotAngle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
                wallShot.transform.rotation = Quaternion.Euler(0, 0, wallShotAngle + 270);

                Rigidbody2D rb = wallShot.GetComponent<Rigidbody2D>();
                rb.linearVelocity = direction * wallShotSpeed;


                //rSidePos = new Vector3 (rSidePos.x, rSidePos.y - 1, rSidePos.z);



                yield return new WaitForSeconds(1f);

            }
        }
    }
    IEnumerator wallSouceTP()
    {

        while (true)
        {
            float tpX = Random.Range(minX, maxX);
            float tpY = Random.Range(minY, maxY);

            Vector3 wallTpPos = new Vector3(tpX, tpY, transform.position.z);

            Vector2 distance = (wallTpPos - playerTransform.position);//.normalized;

            if (distance.magnitude > 0)      //���ȏ㗣��Ă�����ړ�����
            {
                transform.position = new Vector3(tpX, tpY, transform.position.z);

            }
            else  //���W�擾���Ȃ���
            {
                continue;
            }

            //transform.position = new Vector3(tpX, tpY, transform.position.z);
            yield return new WaitForSeconds(1f);
        }


        /*
        Vector2 tpPosToPlayer = (enmTpPos - playerTransform.position);     //����TP��̍��W�ƃv���C���[�̋������v��

        if (tpPosToPlayer.magnitude > 15)      //���ȏ㗣��Ă�����ړ�����
        {
            transform.position = new Vector3(tpX, tpY, transform.position.z);
        }
        else�@�@//���W�擾���Ȃ���
        {
            ranATK = 1;
        }
        */
    }

}
