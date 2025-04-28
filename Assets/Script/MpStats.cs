using UnityEngine;
using System.Collections;
public class MpStats : MonoBehaviour
{
    public static float mp = 0;
    private float maxMp = 30;

    private float mp_ChargeTime = 1f;


    public Color fullMpColor = Color.white;
    public Color lowMpColor = Color.blue;
    private SpriteRenderer spriteRenderer;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        mp = 0;
        StartCoroutine(mpCharge());

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mp == maxMp)
        {
            spriteRenderer.color = Color.blue;
        }
        
        else
        {
            spriteRenderer.color = Color.white;
        }
    }

    IEnumerator mpCharge()
    {
        while (mp < maxMp)
        {
            yield return new WaitForSeconds(mp_ChargeTime);
            mp += 1;
            
            mp = Mathf.Clamp(mp , 0 ,maxMp);


        }


        
    }
}
