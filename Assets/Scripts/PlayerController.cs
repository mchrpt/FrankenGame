using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public GameObject player, swordRotPoint, swordObj;

    // Player movement speed.
    public float lungeSpeed;
    public float moveSpeed;
    public float jumpHeight;
    public float maxJumpAmount;
    public float currJumpAmount;
    // Sword rotation speed.
    public float maxRotSpeed;
    private float currentRotSpeed;
    public Rigidbody2D playerRB;
    
    private Vector2 rotation;
    private int leftOrRight;

    // Determines if both buttons are pressed or not.
    public bool bothPressed;
    public bool pressRelease;

    // Text
    public Text jumpText;
    
    void Start()
    {
        PlayerHealth.jumpAction += resetJump;
        currJumpAmount = maxJumpAmount;
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void resetJump(bool reset)
    {
        currJumpAmount = maxJumpAmount;
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && currJumpAmount > 0)
        {
            playerRB.AddForce(Vector3.up * jumpHeight);
            currJumpAmount--;
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        jumpText.text = currJumpAmount.ToString();
        if (Input.GetKey(KeyCode.A))
        {
            playerRB.AddForce(Vector3.left * moveSpeed);

        }else if (Input.GetKey(KeyCode.D))
        {
            playerRB.AddForce(Vector3.right * moveSpeed);
        }

        if (Input.GetKey(KeyCode.S))
        {

            playerRB.AddForce(Vector3.down * moveSpeed);
        }

        

        if (playerRB.velocity.magnitude > lungeSpeed && bothPressed)
        {
           playerRB.velocity = playerRB.velocity.normalized * lungeSpeed;
        }

        var playerPos = player.transform.position;
        swordRotPoint.transform.position = playerPos;
        
        // A + D are pressed: move based on rotation.
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow) && currJumpAmount > 0)
        {
            
            bothPressed = true;
            pressRelease = true;
            rotation = swordRotPoint.transform.rotation * Vector3.up;
           // Debug.Log(rotation);
            playerRB.AddRelativeForce(rotation, ForceMode2D.Impulse);
            
        }
        else
        {
            bothPressed = false;
            playerRB.velocity -= playerRB.velocity/15;
            if(pressRelease)
            {
                currJumpAmount = 0;
                pressRelease = false;
            }
        }

        // A pressed: clockwise sword rotation.
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            leftOrRight = 1;
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            leftOrRight = -1;
        }


        // Increase rotation speed when either A or D are pressed, and not both at the same time.
        if ((Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) && bothPressed == false)
        {
            // Add to currentRotSpeed until max rotation speed reached.
            if (currentRotSpeed < maxRotSpeed)
                currentRotSpeed += maxRotSpeed/15;
            // Correct speed if it goes above max rotation speed limit.
            if (currentRotSpeed > maxRotSpeed)
                currentRotSpeed = maxRotSpeed;
        }
        else if (currentRotSpeed > 0)
        {
            // Subtract from currentRotSpeed until it reaches or goes below 0.
            currentRotSpeed -= maxRotSpeed/15;
            // Correct currentRotSpeed to 0 if it goes below 0.
            if (currentRotSpeed < 0)
                currentRotSpeed = 0;
        }
        
        // Rotate based on if either A or D are pressed separately, and which direction to rotate in based on directional input.
        // A: counterclockwise, D: clockwise
        swordRotPoint.transform.Rotate(0, 0, currentRotSpeed * leftOrRight * Time.deltaTime);


        

    }
}
