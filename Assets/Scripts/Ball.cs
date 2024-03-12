using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public static Ball instance;

    public GameObject trailObject;
  //  public GameObject ballParticle;

    private void Awake()
    { 
        instance = this;
    }
    void Start()
    {
        trailObject.SetActive(false);
    }

    public void ActivateTrail()
    {
        trailObject.SetActive(true);
       // GameObject ball = Instantiate(ballParticle, ballParticle.transform.position, Quaternion.identity);
       // Destroy(ball, 1f);
    }
 
}
