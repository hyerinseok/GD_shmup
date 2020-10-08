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
            Debug.Log("you're hit! counting : " + count);
        if((isHit == true) && (count > 50))
        {
            this.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
            this.GetComponent<Collider2D>().isTrigger = true;
            isHit = false;
            Debug.Log("not hit!");
        }
        count++;
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
                child.gameObject.transform.SetParent(GameObject.Find("EnemyManager").transform);
                isHit = true;
                count = 0;
            }

            Destroy(other.gameObject);
        }

        if (other.gameObject.tag == "Enemy")
        {
            other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

}








