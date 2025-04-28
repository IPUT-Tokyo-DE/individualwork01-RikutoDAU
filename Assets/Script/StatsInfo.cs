using UnityEngine;

public class StatsInfo : MonoBehaviour
{
    public static float PlayerHP = 100;
    public static float PlayerMaxHP = 100;

    public static float Enm1_HP = 300;
    public static float Enm1_MaxHP = 300;

    //public static int Enm2_HP =30;

    //public static int EnemyA_HP = 10;
    void Start()//”’l‚ğ•Ï‚¦‚éê‡‚Í‚±‚±‚ğ•ÏX
    {
        /*
        PlayerHP = 100;
        PlayerMaxHP = 100;

        Enm1_HP = 300;
        Enm1_MaxHP = 300;
        */
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(PlayerHP);
        
        Debug.Log("Enemy1_" + Enm1_HP);

        //Debug.Log("EnemyA_" + EnemyA_HP);
    }
}
