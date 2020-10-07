using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject enemyProjectile;
    public Sprite[] projectileAttackSprite;

    // Start is called before the first frame update
    void Start()
    {
        int projectileAttackRandomizer = Random.Range (1,9);
        float delay = Random.Range(2f, 10f);
        float rate = Random.Range(2f, 8f);
        InvokeRepeating("Fire", delay, rate);
        this.GetComponent<SpriteRenderer>().sprite = projectileAttackSprite[projectileAttackRandomizer];
    }

    private void Fire()
    {
        int i = Random.Range(0, 100);
        if (i > 80)
        {
            Instantiate(enemyProjectile, new Vector2(transform.position.x, -transform.position.y), Quaternion.identity);
        }
        
        
    }
}
