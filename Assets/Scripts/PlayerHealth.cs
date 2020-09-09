using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int playerHealth;
    public Rigidbody2D rb;
    public Text playerHealthText;
    public static event Action<bool> jumpAction = delegate { };
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        playerHealthText.text = playerHealth.ToString();
       if(playerHealth <= 0)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            playerHealth--;
            //print(playerHealth);
        }
        if (collision.gameObject.tag == "Wall")
        {
            jumpAction(true);
        }
        else
        {
            jumpAction(false);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            jumpAction(true);
        }
        else
        {
            jumpAction(false);
        }
    }
}
