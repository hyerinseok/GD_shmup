using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyProjectile;
    public Sprite[] enemysprite;

    // Start is called before the first frame update
    void Start()
    {
        int spriterandomizer = Random.Range (0,9);
        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        InvokeRepeating("Fire", delay, rate);
        this.GetComponent<SpriteRenderer>().sprite = enemysprite[spriterandomizer];
    }

    private void Fire()
    {
        int i = Random.Range(0, 100);
        if (i > 80)
        {
            Instantiate(enemyProjectile, new Vector2(transform.position.x, -transform.position.y), Quaternion.identity);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Debug.Log("hitwall1");
            //this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }

        if(other.gameObject.name == "RightWall") {
            Debug.Log("pushLeft");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1.0F);
        }
        if(other.gameObject.name == "LeftWall") {
            Debug.Log("pushRight");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1.0F);
        }
        if(other.gameObject.name == "TopWall") {
            //Debug.Log("pushDown");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1.0F);
        }
        if(other.gameObject.name == "BottomWall") {
            //Debug.Log("pushUp");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1.0F);
        }

    }
    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "wall")
        {
            Debug.Log("hitwall2");
            this.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            this.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
        }
/*
        if(other.gameObject.name == "RightWall") {
            Debug.Log("pushLeft");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "LeftWall") {
            Debug.Log("pushRight");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "TopWall") {
            //Debug.Log("pushDown");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "BottomWall") {
            //Debug.Log("pushUp");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1.0F, ForceMode2D.Impulse);
        }
*/
    }
}
