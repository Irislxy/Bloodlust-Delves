using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour 
{
    public GameObject player;
    public GameObject enemy;
    public float damage = 10f;
    public float health = 100f;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            Destroy(enemy);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
        }
    }
}
