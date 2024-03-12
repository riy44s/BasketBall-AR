using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public float resetTimer = 5f;

    private void Start()
    {
        AudioManeger.Instance.musicSource.Stop();
    }

    void Update()
    {
        if(Player.Instance.holdingBall == false)
        {
            resetTimer -= Time.deltaTime;
            if(resetTimer <= 0)
            {
                SceneManager.LoadScene("SampleScene");
            }
        }
    }

}
