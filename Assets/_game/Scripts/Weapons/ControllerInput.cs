using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControllerInput : MonoBehaviour {

    public GameObject impactEffect;
    public Transform gunBarrelTransform;
    public float impactForce = 5f;
   

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger))
        {
            RaycastGun();
        }
	}

    private void RaycastGun()
    {
        RaycastHit hit;

        if (Physics.Raycast(gunBarrelTransform.position, gunBarrelTransform.forward, out hit))
        {
            if (hit.collider.gameObject.CompareTag("Cube"))
            {
                //Destroy(hit.collider.gameObject);

                if(hit.rigidbody != null)
                {
                    hit.rigidbody.AddForce(-hit.normal * impactForce);
                }

                GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal));
                Destroy(impactGO, 0.1f);
            }
        }
    }
}
