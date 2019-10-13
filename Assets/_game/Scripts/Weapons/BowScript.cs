using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowScript : MonoBehaviour {

    float _charge;

    public float chargeMax;
    public float chargeRate;

    public KeyCode fireButton;

    public Transform spawn;
    public Rigidbody arrowObj;

    void Update()
    {
        if(OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger) && _charge < chargeMax)
        {
            
            
            _charge += Time.deltaTime * chargeRate;
            
           Debug.Log(_charge.ToString());

        }

        if(OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger))
        {
           
            Rigidbody arrow = Instantiate(arrowObj, spawn.position, Quaternion.LookRotation(spawn.forward)) as Rigidbody;
            arrow.AddForce(spawn.forward * _charge, ForceMode.Impulse);
            _charge = 0;

            Destroy(arrow, 2f);
            //OVRInput.GetUp(OVRInput.Button.PrimaryIndexTrigger)

        }
    }
}
