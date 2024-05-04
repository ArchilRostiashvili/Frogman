using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//for reloading level
using UnityEngine.SceneManagement;

public class Player_Death : MonoBehaviour
{

    private Rigidbody2D rb;
    private Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap_Spikes"))
        {
            Die();
        }
    }

    private void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("death");
    }

    private void ReloadLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}

