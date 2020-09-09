using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFall : MonoBehaviour
{

    public bool theyCollided;
    public float speed = .1f;
    // Start is called before the first frame update
    void Start()
    {
        theyCollided = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (theyCollided == true)
        {
            transform.position += new Vector3(0f, -speed, 0f) * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //Debug.Log("Fall");
        theyCollided = true;
    }
}
