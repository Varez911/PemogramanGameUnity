using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public Transform lokasiTembakan;
    public LineRenderer garisTujuan;
    public GameObject pointCollider;
    public Rigidbody2D body;

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
        posisiMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(posisiMouse.x - transform.position.x, posisiMouse.y - transform.position.y);
        Debug.Log(direction);
        garisTujuan.SetPosition(0, transform.position);
        lokasiTembakan.right = direction;

        if (Input.GetMouseButtonDown(0))
        {
            garisTujuan.enabled = true;
            Shoot();
        }

        arahGerak = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));

        if (body.velocity.y < -0.1)
        {
            garisTujuan.enabled = false;
        }
    }

    private void FixedUpdate()
    {
        Move(arahGerak, kecepatan);
    }

    void Move(Vector2 arahGerak, float Kecepatan)
    {
        body.AddForce(arahGerak * Kecepatan);
    }

    void Shoot()
    {
        RaycastHit2D collide = Physics2D.Raycast(lokasiTembakan.position, lokasiTembakan.right);
        if (collide.collider != null)
        {
            garisTujuan.SetPosition(1, (Vector3)collide.point);
            Instantiate(pointCollider, (Vector3)collide.point, lokasiTembakan.rotation);
            Move(-collide.normal * jumpHeight, kecepatan);
        }
    }
}
