using UnityEngine;

public class PlayerHpColor : MonoBehaviour
{

    public Color fullHPColor = Color.green;
    public Color lowHPColor = Color.red;

    private float changeValue = 0f;


    private SpriteRenderer spriteRenderer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.color = fullHPColor;
    }

    // Update is called once per frame
    void Update()
    {
        changeValue = 1f - (StatsInfo.PlayerHP / StatsInfo.PlayerMaxHP);
        spriteRenderer.color = Color.Lerp(fullHPColor, lowHPColor, Mathf.Clamp01(changeValue));
    }
}
