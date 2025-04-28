using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayButtonHard : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    // Update is called once per frame
    void onClick()
    {
        StatsInfo.PlayerHP = StatsInfo.PlayerMaxHP;
        StatsInfo.Enm1_HP = StatsInfo.Enm1_MaxHP;
        MpStats.mp = 0;
        SceneManager.LoadScene("STAGE-Hard");
    }
}
