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

    void Update() {
        if(this.transform.position.x < GameObject.Find("LeftWall").transform.position.x)
            this.transform.position = new Vector3(GameObject.Find("LeftWall").transform.position.x + 1.0f, this.transform.position.y, 0);
        if(this.transform.position.x > GameObject.Find("RightWall").transform.position.x)
            this.transform.position = new Vector3(GameObject.Find("RightWall").transform.position.x - 1.0f, this.transform.position.y, 0);
        if(this.transform.position.y < GameObject.Find("BottomWall").transform.position.y)
            this.transform.position = new Vector3(this.transform.position.x, GameObject.Find("BottomWall").transform.position.y + 1.0f, 0);
        if(this.transform.position.y > GameObject.Find("TopWall").transform.position.y)
            this.transform.position = new Vector3(this.transform.position.x, GameObject.Find("TopWall").transform.position.y - 1.0f, 0);
    }

    private void Fire()
    {
        int i = Random.Range(0, 100);
        if (i > 80)
        {
            Instantiate(enemyProjectile, new Vector2(transform.position.x, -4), Quaternion.identity);
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
        if(other.gameObject.name == "RightWall") {
            Debug.Log("pushLeft");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.left * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "LeftWall") {
            Debug.Log("pushRight");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.right * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "TopWall") {
            Debug.Log("pushDown");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.down * 1.0F, ForceMode2D.Impulse);
        }
        if(other.gameObject.name == "BottomWall") {
            Debug.Log("pushUp");
            this.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 1.0F, ForceMode2D.Impulse);
        }
    }
}
