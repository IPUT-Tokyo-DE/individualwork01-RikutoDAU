using UnityEngine;
using System.Collections;

public class EnemyCon : MonoBehaviour
{
    private float distance;

    private bool enmLowHP;

    public static int ranAtk;

    private int ranAtkMin = 1;
    private int ranAtkMax = 8;

    public Transform playerTransform;

    private float minX = -0;
    private float maxX = 10;
    private float minY = 0;   //移動範囲
    private float maxY = 12;

    private float ranLoopTime = 3f;     //敵行動取得周期


    public GameObject EnmShotPrefab;    //弾prefab選択
    private float enmShotSpeed = 5f;    //通常弾速度

    public GameObject enmTageShotPrefab;   //プレイヤーに直線弾
    private float enmTageShotSpeed = 15f;

    public GameObject LaserObPrefab;
    public GameObject LaserSignPrefab;
    private float LaserSpeed;

    public GameObject EnemyAPrefab;

    /*
    public GameObject enmWalLShotPrefab;
    private float wallShotSpeed = 5f;
    */

    //private bool AtR360;

    void Start()
    {
        enmLowHP = false;
        StartCoroutine(randomTake());
        StartCoroutine(randomTake2());
        ranAtk = 0;
    }

    void Update()
    {

        if (StatsInfo.Enm1_HP <= 0)
        {
            Destroy(this.gameObject);
        }
        Debug.Log(ranAtk);

        float distance = Vector3.Distance(transform.position, playerTransform.position);


        //Debug.Log(distance);

        if (distance < 2f)
        {
            enmTP();
        }

        if (ranAtk == 1)    //テレポート
        {
            //enmTP();

            ranAtk = 0;
        }

            if (ranAtk == 2)    //360/12全方向
        {
            StartCoroutine (Test360ATK());
        }


        if (ranAtk == 3)
        {
            StartCoroutine(tageShot());
        }

        
        if (ranAtk == 4)
        {
            StartCoroutine(Laser());
        }

        if (ranAtk == 5)
        {
            //StartCoroutine(wallShot());
        }

        // ranATK == 6 はtageLazer


        if (ranAtk == 7)
        {
            EnemyASpw();
        }

        if (StatsInfo.Enm1_HP < StatsInfo.Enm1_MaxHP * 2 / 3 && enmLowHP == false)
        {
            StartCoroutine(lowHPTP());
        }


    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerShot"))
        {
            //StatsInfo.Enm1_HP -= 1;
        }
    }


    IEnumerator Enm360ATK()
    {
        /*
        for (int i = 0; i < 12; ++i)
        {
            // 弾丸を生成
            GameObject enmShot = Instantiate(EnmShotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = enmShot.GetComponent<Rigidbody2D>();

                // 発射方向を計算（円周上に配置）
                Vector2 direction = new Vector2(
                    Mathf.Cos(Mathf.Deg2Rad * (30 * i)),
                    Mathf.Sin(Mathf.Deg2Rad * (30 * i))
                ).normalized;

                // 力を加えて弾丸を発射
                rb.AddForce(direction * enmShotSpeed, ForceMode2D.Impulse);

        }
        */
        // 次の弾発射まで1秒間待機
            yield return new WaitForSeconds(1f);
    }


    IEnumerator Test360ATK()
    {

        ranAtk = 0;
        for (int i = 0; i < 36; ++i)
        {
            // 弾丸を生成
            GameObject enmShot = Instantiate(EnmShotPrefab, transform.position, Quaternion.identity);
            Rigidbody2D rb = enmShot.GetComponent<Rigidbody2D>();

            // 発射方向を計算（円周上に配置）
            Vector2 direction = new Vector2(
                Mathf.Cos(Mathf.Deg2Rad * (15 * i)),
                Mathf.Sin(Mathf.Deg2Rad * (15 * i))
            ).normalized;

            // 力を加えて弾丸を発射
            rb.AddForce(direction * enmShotSpeed, ForceMode2D.Impulse);


        }
        yield return null;
    }

    IEnumerator tageShot()
    {
        ranAtk = 0;
        for (int i = 0; i <= 10; ++i)
        {
            Vector3 enmPos = this.gameObject.transform.position;

            Vector2 direction = (playerTransform.position - enmPos).normalized;// playerTransform.position - enmPos;

            GameObject enmTageShot = Instantiate(enmTageShotPrefab, transform.position, Quaternion.identity);


            Rigidbody2D rb = enmTageShot.GetComponent<Rigidbody2D>();
            rb.linearVelocity = direction * enmTageShotSpeed;
            yield return  new WaitForSeconds(0.3f);
        }
    }

    IEnumerator Laser()
    {
        ranAtk = 0;

        for (int i = 0; i < 3; ++i) //レーザの軌道警告を3回出す
        {
            Vector3 enmPosSign = this.gameObject.transform.position;
            Vector2 directionSign = (playerTransform.position - enmPosSign).normalized;

            GameObject LaserSign = Instantiate(LaserSignPrefab, transform.position, Quaternion.identity);

            float angleSign = Mathf.Atan2(directionSign.y, directionSign.x) * Mathf.Rad2Deg;    //角度を調整
            LaserSign.transform.rotation = Quaternion.Euler(0, 0, angleSign + 0);

            yield return new WaitForSeconds(0.1f);
            Destroy(LaserSign);
            yield return new WaitForSeconds(0.1f);
        }
        
        Vector3 enmPos = this.gameObject.transform.position;
        Vector2 direction = (playerTransform.position - enmPos).normalized;
        
        yield return new WaitForSeconds(0.4f);

        /*
        Vector3 enmPos = this.gameObject.transform.position;
        Vector2 direction = (playerTransform.position - enmPos).normalized;
        */

        GameObject LaserOb = Instantiate(LaserObPrefab, enmPos, Quaternion.identity);

        float angleLaser = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        LaserOb.transform.rotation = Quaternion.Euler(0, 0, angleLaser + 0);

        Rigidbody2D rb = LaserOb.GetComponent<Rigidbody2D>();
        rb.linearVelocity = direction * 100f;
        yield return new WaitForSeconds(1f);
        Destroy(LaserOb);


    }


    void EnemyASpw()
    {
        ranAtk = 0;

        float tpX = Random.Range(minX, maxX);
        float tpY = Random.Range(minY, maxY);

        Vector3 enmASpwPos = new Vector3(tpX, tpY, transform.position.z);

        Vector2 enmASpwPosToPlayer = (enmASpwPos - playerTransform.position);     //得たTP先の座標とプレイヤーの距離を計測

        if (enmASpwPosToPlayer.magnitude > 5)      //一定以上離れていたら移動許可
        {
            GameObject EnemyA = Instantiate(EnemyAPrefab, enmASpwPos, Quaternion.identity);
        }
        else　　//座標取得しなおす
        {
            ranAtk = 7;
        }

    }

    void enmTP()
    {
        while (true)
        {

            float tpX = Random.Range(minX, maxX);
            float tpY = Random.Range(minY, maxY);

            Vector3 enmTpPos = new Vector3(tpX, tpY, transform.position.z);

            Vector2 tpPosToPlayer = (enmTpPos - playerTransform.position);     //得たTP先の座標とプレイヤーの距離を計測

            if (tpPosToPlayer.magnitude > 5)      //一定以上離れていたら移動許可
            {
                transform.position = new Vector3(tpX, tpY, transform.position.z);
                break;
            }
            else  //座標取得しなおす
            {
                continue;
            }

        }

    }

    IEnumerator lowHPTP()
    {

        enmLowHP = true;
        while (StatsInfo.Enm1_HP > 0)
        {
            float tpX = Random.Range(minX, maxX);
            float tpY = Random.Range(minY, maxY);

            Vector3 enmTpPos = new Vector3(tpX, tpY, transform.position.z);

            Vector2 tpPosToPlayer = (enmTpPos - playerTransform.position);     //得たTP先の座標とプレイヤーの距離を計測

            if (tpPosToPlayer.magnitude > 5)      //一定以上離れていたら移動許可
            {
                transform.position = new Vector3(tpX, tpY, transform.position.z);
                yield return new WaitForSeconds(3f);

                continue;
            }
            else
            {
                continue;
            }
            
        }
    }

    IEnumerator randomTake()    //ランダム数値取得
    {
        while (StatsInfo.Enm1_HP > 0)
        {
            ranAtk = Random.Range(ranAtkMin, ranAtkMax);

            yield return new WaitForSeconds(ranLoopTime);

            continue;
        }
        

    }


    IEnumerator randomTake2()    //ランダム数値取得
    {
        while (StatsInfo.Enm1_HP > 0)
        {
            ranAtk = Random.Range(ranAtkMin, ranAtkMax);

            yield return new WaitForSeconds(ranLoopTime +2);

            continue;
        }


    }


}