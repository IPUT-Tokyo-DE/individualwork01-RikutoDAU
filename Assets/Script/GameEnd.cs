using UnityEngine;

public class GameEnd : MonoBehaviour
{

    public GameObject reStartButton;
    public GameObject toMainManuButton;

    public GameObject gameClear;
    public GameObject gameOver;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        reStartButton.SetActive(false);
        toMainManuButton.SetActive(false);

        gameClear.SetActive(false);
        gameOver.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        if (StatsInfo.PlayerHP <= 0)
        {
            reStartButton.SetActive(true);
            toMainManuButton.SetActive(true);

            gameOver.SetActive(true);
        }

        else if(StatsInfo.Enm1_HP <= 0)
        {
            reStartButton.SetActive(true);
            toMainManuButton.SetActive(true);

            gameClear.SetActive(true);
        }
    }
}
