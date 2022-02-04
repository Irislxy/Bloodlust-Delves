using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class EnemyManager : MonoBehaviour 
{
    public GameObject player;
    public GameObject enemy;
    public GameObject expl;
    public float damage = 10f;
    public float health = 100f;

    public Slider slider;

    public float pushPower = 150f;

    public NavMeshAgent enemyMeshAgent;

    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0)
        {
            
            var explosion = Instantiate(expl, enemy.transform.position, Quaternion.identity);

            ScoreScript.scoreValue += 10;

            Destroy(enemy);
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        enemyMeshAgent.SetDestination(player.transform.position);
        slider.value = health;
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject == player)
        {
            player.GetComponent<PlayerManager>().Hit(damage);
            Vector3 pushDir =  collision.transform.position - transform.position;
            player.GetComponent<PlayerMovement>().AddForce(pushDir * pushPower);//(new Vector3(pushDir.x,0,pushDir.z) * pushPower);
        }

        
    }

    
}
