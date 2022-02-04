using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;
    public float damage = 25f;

    public ParticleSystem muzzleFlash;
    public AudioClip gunShotSound;
    private AudioSource audioSource; 


    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if(audioSource == null){
            Debug.Log("Error");
        }

        audioSource.clip = gunShotSound;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }

    }

    void Shoot()
    {
        muzzleFlash.Play();
        audioSource.PlayOneShot(audioSource.clip);

        RaycastHit hit;

        if (Physics.Raycast(playerCam.transform.position, playerCam.transform.forward, out hit, range))
        {

            EnemyManager enemyManager = hit.transform.GetComponent<EnemyManager>();
            if (enemyManager != null)
            {
                enemyManager.Hit(damage);
            }
            

            Debug.Log(hit.transform.name);
            //Debug.DrawRay(playerCam.transform.position, playerCam.transform.forward, Color.red, 5.0f);

        }
    }

}
