using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //public Transform lokasiTembakan;
    //public LineRenderer garisTujuan;
    //public GameObject pointCollider;
    public SpriteRenderer sprite;
    public Rigidbody2D body;
    public BoxCollider2D box;
    public Animator animator;

    public float jumpHeight = 80f;
    public float kecepatan = 20f;

    private Vector2 posisiMouse;
    private Vector2 arahGerak;
    //private float arahGerak;
    private float jump;
    //Hanya saat Scene di mulai
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    //Dipanggil berkali kali saat frame di update
    void Update()
    {
        //Debug.Log(body.velocity.x);
        arahGerak = new Vector2(Input.GetAxisRaw("Horizontal"),0);
        //arahGerak = Input.GetAxisRaw("Horizontal"); 
        
        if (arahGerak.x < 0)
        {
            sprite.flipX = true;
        }
        else if (arahGerak.x > 0)
        {
            sprite.flipX = false;
        }
        else
        {
            sprite.flipX = sprite.flipX;
        }

        jump = Input.GetAxisRaw("Vertical");


        animator.SetFloat("Speed", Mathf.Abs(arahGerak.x));
        //animator.SetFloat("Airbone", arahGerak);
        //animator.SetBool("Ground", isGrounded());
    }

    private void FixedUpdate()
    {
        Move(arahGerak, kecepatan);
        playerJump();
    }

    void Move(Vector2 arahGerak, float Kecepatan)
    {
        //body.MovePosition((Vector2)transform.position + (arahGerak * Kecepatan * Time.deltaTime));
        //transform.position += new Vector3(arahGerak, 0, 0) * Kecepatan * Time.deltaTime;
       // body.AddForce(arahGerak * kecepatan * Time.deltaTime);
    }
    
    void playerJump()
    {
        body.AddForce(new Vector2(0, jump * jumpHeight), ForceMode2D.Impulse);
    }

    private bool isGrounded()
    {
        float extraHeight = .2f;
        RaycastHit2D hit = Physics2D.Raycast(box.bounds.center, Vector2.down, box.bounds.extents.y + extraHeight);
        
        Debug.DrawRay(box.bounds.center, Vector2.down *(box.bounds.extents.y + extraHeight), Color.green);
        return hit.collider != null;
    }

}
