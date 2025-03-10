using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyAi : MonoBehaviour
{
    public Transform Player;  
    public float Speed = 6f;
    private playerMovement playerMovementScript;
    private Animator animator;
    private bool canAttack = false;

    void Start()
    {
        playerMovementScript = Player.GetComponent<playerMovement>();
        animator = GetComponent<Animator>();
        StartCoroutine(EnableAttack());
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, Player.position, Speed * Time.deltaTime);
        animator.SetBool("Chase", true);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (canAttack && other.CompareTag("Player"))
        {
            playerMovementScript.Die();
            
        }
    }

    IEnumerator EnableAttack()
    {
        yield return new WaitForSeconds(1f); 
        canAttack = true; 
    }

    void Die()
    {
        animator.SetBool("Chase", false);
        Destroy(gameObject,2f);  
    }
}