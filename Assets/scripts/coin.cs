using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SocialPlatforms.Impl;
public class coin : MonoBehaviour
{
    public AudioClip coinSound;
   


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Obstacle")) 
        {
            
            Destroy(gameObject);
        }



        if (other.CompareTag("Player"))
        {

            AudioSource playerAudio = other.GetComponent<AudioSource>();
            playerAudio.PlayOneShot(coinSound);
            Destroy(gameObject);
            GameManager.Instance.score++;
           


        }

        

    }
 
}
