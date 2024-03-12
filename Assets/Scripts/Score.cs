using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    public static Score instanse;
    public int count = 0;
    public TextMeshProUGUI countText;

    public GameObject gameOver;
    public GameObject WinObject;

     public int moves = 5;
    private bool wasHoldingBall;
    public TextMeshProUGUI movesText;
    public GameObject hit;
    public GameObject scoringParticle;
    public AudioClip hitSound;
    private void Awake()
    {
        instanse = this;

        Score[] existingInstances = FindObjectsOfType<Score>();

        if (existingInstances.Length > 1)
        {
         
            Destroy(gameObject);
        }
        else 
        {
           
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        if (!Player.Instance.holdingBall && wasHoldingBall)
        {
            Moves(); 
            wasHoldingBall = false;
        }
        else if (Player.Instance.holdingBall)
        {
            wasHoldingBall = true;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Hoop"))
        {
            if (!scoringParticle.activeInHierarchy)
            {
                count++;
                scoringParticle.SetActive(true);
                countText.text = "Score : " + count;
                GameObject scoring = Instantiate(scoringParticle, scoringParticle.transform.position, Quaternion.identity);
                Destroy(scoring, 1f);
               
            }

            scoringParticle.SetActive(false);

            if (!hit.activeInHierarchy)
            {
                hit.SetActive(true);
                AudioManeger.Instance.sfxSource.PlayOneShot(hitSound);
                GameObject hitdistroy =  Instantiate(hit, hit.transform.position, Quaternion.identity);
                Destroy(hitdistroy, 1f);              
            }
            hit.SetActive(false);   
         

            if (count == 10)
            {
                Win();
            }          
        }
    }

    public void GameOver()
    {
        Time.timeScale = 0;
        gameOver.SetActive(true);
    }

    public void Win()
    {
        Time.timeScale = 0;
        WinObject.SetActive(true);
    }

    public void Moves()
    {
        moves--;
        movesText.text = "Moves Remaining : " + moves;
        Debug.Log("moves" + moves);
        if (moves <= 0)
        {
           GameOver();
        }
    }   

    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        gameOver.SetActive(false);
        WinObject.SetActive(false);
        moves = 15;
        count = 0;
        wasHoldingBall = false;
        countText.text = "Score : " + count;
        movesText.text = "Moves Remaining : " + moves;
    }
}
