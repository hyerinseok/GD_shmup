using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviour {
    private float     xPos, yPos;
    public float      speed = .05f;
    public float      leftWall, rightWall, topWall, bottomWall;
    public float health = 1f;
    
    public GameObject projectile;
    public Image healthBar;
    public KeyCode fireKey;

    Boolean isHit = false;
    int count = 0;
    
    // Start is called before the first frame update
    void Start() {
        //healthBar.fillAmount = health;
        isHit = false;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetKey(KeyCode.LeftArrow)) {
            if (xPos > leftWall) {
                xPos -= speed;
            }
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            if (xPos < rightWall) {
                xPos += speed;
            }
        }

        if (Input.GetKey(KeyCode.UpArrow)) {
            if (yPos < topWall) {
                yPos += speed;
            }
        }

        if (Input.GetKey(KeyCode.DownArrow)) {
            if (yPos > bottomWall) {
                yPos -= speed;
            }
        }

        if (Input.GetKeyDown(fireKey))
        {
            //Instantiate(projectile, new Vector2(transform.position.x, transform.position.y + 0.5f), Quaternion.identity);
        }
        transform.localPosition = new Vector3(xPos, yPos, 0);

        if(isHit == true)
        {
            //Debug.Log("you're hit! counting : " + count);
        }

        if((isHit == true) && (count > 150))
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.GetComponent<Collider2D>().isTrigger = true;
            isHit = false;
            //Debug.Log("not hit!");
            this.GetComponent<SpriteRenderer>().color = Color.white;
        }
        count++;

        //slows down the player depending on how many planets it's carrying.
        speed = .05f * Mathf.Pow(0.99f, this.transform.childCount);

        foreach (Transform child in this.transform)
        {
            if(Vector3.Distance(transform.position, child.position) > 1.5)
            {
                Debug.Log("too far away");
                child.gameObject.transform.SetParent(GameObject.Find("EnemyManager2").transform);
                child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                child.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                child.gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.position, ForceMode2D.Impulse);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "EnemyProjectile")
        {
            //health -= .1f;
            //healthBar.fillAmount = health;
            this.GetComponent<Collider2D>().isTrigger = false;
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
            foreach (Transform child in this.transform)
            {
                child.gameObject.transform.SetParent(GameObject.Find("EnemyManager2").transform);
                child.gameObject.GetComponent<SpriteRenderer>().color = Color.white;
                child.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                child.gameObject.GetComponent<Rigidbody2D>().AddForce(this.transform.position, ForceMode2D.Impulse);
            }

            isHit = true;
            count = 0;
            this.GetComponent<SpriteRenderer>().color = Color.red;

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy" && isHit == false)
        {
            other.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            other.gameObject.GetComponent<Rigidbody2D>().angularVelocity = 0f;
            other.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
            other.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

}








