using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class playerMovement : MonoBehaviour
{
    bool alive = true;
    public float speed = 10;
    public Rigidbody rb;
    float HorizontalInput;
    public float maxSpeed = 20;
    public float speedIncreaseRate = 0.1f;

    public int maxLives = 3;
    public Text livesText;
    public GameObject gameOverScreen;

    public Animator animator;

    public float jumpHieght = 5f;

    public bool isGrounded ;
    public int lives;

    public AudioSource audioSource;
    public AudioClip jumpSound;
    public AudioClip coinSound;
    public AudioClip collisionSound;

    public ParticleSystem jumpEffect;
    public Transform jumpEffectPosition;
    




    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        lives = maxLives;
         UpdateUI();
        jumpEffect.Stop();
       

    }
    public void Move()
    {
       

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * HorizontalInput * speed * Time.fixedDeltaTime;
        Vector3 newPosition = rb.position + forwardMove + horizontalMove;
        newPosition.x = Mathf.Clamp(newPosition.x, -5f, 5f);
        rb.MovePosition(newPosition);




    }

  


    void jump()
    {
        float jumpVelocity = Mathf.Sqrt(2 * -Physics.gravity.y * jumpHieght);
        rb.velocity = new Vector3(rb.velocity.x, jumpVelocity, rb.velocity.z);
         isGrounded = false;

        audioSource.PlayOneShot(jumpSound);
        animator.SetBool("isJumping", true);
       

        jumpEffect.transform.position = jumpEffectPosition.position;
        jumpEffect.Play();
    }

    IEnumerator IncreaseSpeedOverTime()
    {
        while (alive && speed < maxSpeed)
        {
            speed += speedIncreaseRate;
            yield return new WaitForSeconds(1f);
        }
    }


    private void FixedUpdate()
    {
        if(!alive )return;
        Move();
        
    }

    private void Update()
    {
        HorizontalInput = Input.GetAxisRaw("Horizontal");
        

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            jump();
        }

        

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("isJumping", false);
            
            jumpEffect.Stop();
            

        }

        if (collision.gameObject.CompareTag("Wall") || collision.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("damage");
            audioSource.PlayOneShot(collisionSound);

      
             TakeDamage();
            
        }

        

    }

   



    public void TakeDamage()
    {
        lives--;
        UpdateUI();
        if (lives <= 0)
        {
            Die();
           
        }
    }

    public void Die()
    {
        alive = false;
        gameOverScreen.SetActive(true);
        Invoke("HOME", 2f);
    }

  



    void UpdateUI()
    {
        livesText.text = " LIFE : " + lives;
    }


    void HOME()
    {
       
        SceneManager.LoadScene(0);
    }

}
