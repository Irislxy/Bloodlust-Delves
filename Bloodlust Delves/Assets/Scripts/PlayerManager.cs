using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    public float health = 100;
    public Slider slider;

    public void Hit(float damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            SceneManager.LoadScene("LoseScene");
        }

    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = health;
    }
}
