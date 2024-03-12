using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;


    public GameObject playerCamera;
    public float ballDistance = 2f;
    public float ballThrowingForce = 5f;

    public bool holdingBall = true;

    public AudioClip ball;

    private void Awake()
    {
        Instance = this;    
    }
    void Start()
    {
        Ball.instance.GetComponent<Rigidbody>().useGravity = false;
    }

    void Update()
    {
        if (holdingBall)
        {
            Ball.instance.transform.position = playerCamera.transform.position + playerCamera.transform.forward * ballDistance;

            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    Vector3 targetPosition = hit.point;

                    holdingBall = false;
                    Ball.instance.ActivateTrail();
                    Ball.instance.GetComponent<Rigidbody>().useGravity = true;
                    Ball.instance.GetComponent<Rigidbody>().AddForce((targetPosition - playerCamera.transform.position).normalized * ballThrowingForce);
                    AudioManeger.Instance.sfxSource.PlayOneShot(ball);
                }
            }
        }
    }
}
