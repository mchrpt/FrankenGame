using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : MonoBehaviour
{

    public int speed;
    private bool onGround;
    public int jumpSpeed;
    public Rigidbody2D rigidbody2d;
   
    // Start is called before the first frame update
    void Start()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed, 0f, 0f) * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed, 0f, 0f) * Time.deltaTime;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
                rigidbody2d.AddForce(new Vector2(0f, jumpSpeed), ForceMode2D.Impulse);
        }

    }
 
}
