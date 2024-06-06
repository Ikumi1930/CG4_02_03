using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 1.0f;
        const float jumpSpeed = 7.0f;

        Vector3 v = rb.velocity;
        if(Input.GetKey(KeyCode.RightArrow))
        {
            v.x = moveSpeed;
        }
        //ç∂à⁄ìÆ
       // Vector3 v = rb.velocity;
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            v.x = -moveSpeed;
        }
        else
        {
            v.x = 0;
        }
        //ÉWÉÉÉìÉv
        if (Input.GetKeyDown(KeyCode.Space))
        {
            v.y = jumpSpeed;
        }
        rb.velocity = v;

       
        





    }

}


