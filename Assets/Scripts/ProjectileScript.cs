using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    public float               speed = 2f;
    public int direction = -1;
    private Rigidbody2D        rb;
    public GameObject player;
Vector3 dir, side;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine("Swipe");

    }

    void Update(){
        //transform.RotateAround(GameObject.Find("Player").transform.position, Vector3.forward, 1000 * Time.deltaTime);
    }

    private IEnumerator Swipe() {
        yield return new WaitForSeconds(1);
        //rb.AddForce(transform.right * -1);
        rb.AddForce(-transform.up * speed * direction);
        //rb.AddForce(GameObject.Find("Player").transform.position);
        yield return null;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy"){
            return;
        }

        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            // award points
            Destroy(other.gameObject);
            Destroy(this.gameObject);
        }

        if (other.gameObject.tag == "wall")
        {
            Destroy(this.gameObject);
        }
    }
}
