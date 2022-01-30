using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{
    public GameObject playerCam;
    public float range = 100f;

    public ParticleSystem muzzleFlash;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            //Debug.Log("Shoot");
            Shoot();

        }
        
    }

    void Shoot()
    {
        muzzleFlash.Play();

        RaycastHit hit;

        if(Physics.Raycast(playerCam.transform.position, transform.forward, out hit, range))
        {
            Debug.Log("hit");
        }

    }
}
