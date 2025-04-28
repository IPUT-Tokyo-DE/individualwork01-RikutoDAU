using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PlayDebugHard : MonoBehaviour
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
        StatsInfo.PlayerHP = 10000000;
        StatsInfo.Enm1_HP = 10;
        MpStats.mp = 30;
        SceneManager.LoadScene("STAGE-Hard");
    }
}
