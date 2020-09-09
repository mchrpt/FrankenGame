using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform getCubeTR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //print(transform.position.x);
     Vector3 cubeTr = new Vector3(getCubeTR.position.x, getCubeTR.position.y, transform.position.z);
     transform.position = cubeTr;
    }
}
