using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class PizzaSteve : MonoBehaviour
{
    // Start is called before the first frame update

    public float score = 0;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.CompareTag("fire"))
        {
            score += 0.2f;
        }
        //Debug.Log("Score: " + score);
    }
}
