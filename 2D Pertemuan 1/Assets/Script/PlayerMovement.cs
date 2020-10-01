using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Transform lokasiTembak;
    public GameObject bullet;
    public float kecepatan;
    public float jumpHeight;

    private Vector2 arahGerak;
    // Start is called before the first frame update
    void Start()
    {
        rb2D = this.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 mouseposition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 arahGerakMouse = new Vector2(mouseposition.x - transform.position.x, mouseposition.y - transform.position.y);
        //lihatMouse(arahGerakMouse);
        arahGerak = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        if (Input.GetMouseButtonDown(0))
        {
            //Shoot();
        }
        
    }

    private void FixedUpdate()
    {
        bergerak(kecepatan, arahGerak);
    }

    void lihatMouse(Vector2 arahMouse)
    {
        transform.right = arahMouse;
    }

    void Shoot()
    {
        RaycastHit2D hit = Physics2D.Raycast(lokasiTembak.position, lokasiTembak.right);
        if (hit.collider != null)
        {
            Debug.Log(hit.normal);
            arahGerak = hit.normal;
            bergerak(jumpHeight, arahGerak);
            Instantiate(bullet, lokasiTembak.position, lokasiTembak.rotation);
        }
    }

    void bergerak(float kecepatan, Vector2 arahGerak)
    {
        rb2D.AddForce(arahGerak * kecepatan);
    }
}
