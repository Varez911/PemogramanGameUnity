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
    //Hanya saat Scene di mulai
    void Start()
    {
        body = this.GetComponent<Rigidbody2D>();
    }

    //Dipanggil berkali kali saat frame di update
    void Update()
    {
        Debug.Log(body.velocity.y);
        arahGerak = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical") * jumpHeight);
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
        animator.SetFloat("Speed", Mathf.Abs(arahGerak.x));
        animator.SetFloat("Airbone", arahGerak.y);
        animator.SetBool("Ground", isGrounded());
    }

    private void FixedUpdate()
    {
        Move(arahGerak, kecepatan);
    }

    void Move(Vector2 arahGerak, float Kecepatan)
    {
        body.MovePosition((Vector2)transform.position + (arahGerak * Kecepatan * Time.deltaTime));
        //body.AddForce(arahGerak * kecepatan);
    }

    private bool isGrounded()
    {
        float extraHeight = .2f;
        RaycastHit2D hit = Physics2D.Raycast(box.bounds.center, Vector2.down, box.bounds.extents.y + extraHeight);
        
        Debug.DrawRay(box.bounds.center, Vector2.down *(box.bounds.extents.y + extraHeight), Color.green);
        return hit.collider != null;
    }

    void Shoot()
    {
        /*
        RaycastHit2D collide = Physics2D.Raycast(lokasiTembakan.position, lokasiTembakan.right);
        if (collide.collider != null)
        {
            garisTujuan.SetPosition(1, (Vector3)collide.point);
            Instantiate(pointCollider, (Vector3)collide.point, lokasiTembakan.rotation);
            Move(-collide.normal * jumpHeight, kecepatan);
        }
        */
    }
}
