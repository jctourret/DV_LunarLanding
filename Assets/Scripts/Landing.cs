using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Landing : MonoBehaviour
{
    float scoreWorth = 50;

    Rigidbody2D rb;

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            if (collision.collider){

            }
        }
    }

}
