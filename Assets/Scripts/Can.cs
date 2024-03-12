using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Can : MonoBehaviour
{
    private void Awake()
    {
        Canvas[] existingInstances = FindObjectsOfType<Canvas>();

        if (existingInstances.Length > 1)
        {

            Destroy(gameObject);
        }
        else
        {

            DontDestroyOnLoad(this.gameObject);
        }
    }
}
