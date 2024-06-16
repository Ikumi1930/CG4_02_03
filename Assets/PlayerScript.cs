using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;


public class PlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject bombParticle;
    private bool isBlock = true;
    private AudioSource audioSource;
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        transform.rotation = Quaternion.Euler(0, 90, 0);
        GameManagerScript.score = 0;
    }


    // Update is called once per frame
    void Update()
    {
        const float moveSpeed = 1.0f;
        const float jumpSpeed = 7.0f;
        float stick = Input.GetAxis("Horizontal");


        Vector3 v = rb.velocity;
        if (Input.GetKey(KeyCode.RightArrow) || stick>0)
        {
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0,90,0);
            v.x = moveSpeed;
        }
        //左移動
        // Vector3 v = rb.velocity;
        else if (Input.GetKey(KeyCode.LeftArrow) || stick<0)
        {
            animator.SetBool("walk", true);
            transform.rotation = Quaternion.Euler(0, -90, 0);
            v.x = -moveSpeed;
        }
        else
        {
            animator.SetBool("walk", false);
            v.x = 0;
        }



        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    animator.SetBool("mode", true);
        //}

        //if (Input.GetKeyDown(KeyCode.B))
        //{
        //    animator.SetBool("mode", false);
        //}


        //プレイヤーの下方向へレイを出す
        Vector3 rayPosition = transform.position + new Vector3(0.0f,0.8f,0.0f);
        Ray ray = new Ray(rayPosition, Vector3.down);
        float distance = 0.9f;
        Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

        isBlock = Physics.Raycast(ray, distance);
        if (isBlock == true)
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.red);

            animator.SetBool("jump", false);
            //ジャンプ
            if (Input.GetButtonDown("Jump"))
            {
                v.y = jumpSpeed;
            }
        }
        else
        {
            Debug.DrawRay(rayPosition, Vector3.down * distance, Color.yellow);
            animator.SetBool("jump", true);
        }
        rb.velocity = v;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "COIN")
        {
            other.gameObject.SetActive(false);
            audioSource.Play();
            GameManagerScript.score += 1;
            Instantiate(bombParticle, transform.position, Quaternion.identity);
        }
    }
}


