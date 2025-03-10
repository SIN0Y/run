using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public  int score;
    public AudioSource audioSource;  
    public AudioClip coinSound;
    public TextMeshProUGUI scoreText;
    public static GameManager Instance;

    public void Awake()
    {
        Instance = this;
    }


    public void PlayCoinSound()
    {
        if (audioSource != null && coinSound != null)
        {
            audioSource.PlayOneShot(coinSound);
        }
    }

    private void Update()
    {
        scoreText.text = "Score: " + score;
    }
}
