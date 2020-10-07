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
    
    // Start is called before the first frame update
    void Start() {
        //healthBar.fillAmount = health;
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
    }

    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.tag == "EnemyProjectile")
        {
            Destroy(other.gameObject);
            //health -= .1f;
            //healthBar.fillAmount = health;
            foreach (Transform child in transform)
            {
                child.gameObject.transform.SetParent(GameObject.Find("EnemyManager").transform);
                child.GetComponent<Rigidbody2D>().isKinematic = true;
                child.GetComponent<Rigidbody2D>().AddForce(GameObject.Find("Player").transform.position);
                //child.GetComponent<Rigidbody2D>().isKinematic = false;
            }

        }

        if (other.gameObject.tag == "Enemy")
        {
        other.gameObject.transform.SetParent(this.gameObject.transform);
        }
    }

}








