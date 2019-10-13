using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellDraw : MonoBehaviour {

    public float thisOrb;
    public float totalOrbs;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider col)
    {
       

        //touches wand
        if (col.GetComponent<WandScript>())
        {
            //Debug.Log("pressed");
            WandScript wandScript = col.GetComponent<WandScript>();
            wandScript.spellDrawTrigger(thisOrb, totalOrbs);
            
            //PARTICLE EFFECT
            // GameObject impactGO = Instantiate(impactEffect, arrowspawn.position, Quaternion.LookRotation(arrowspawn.forward));
            // Destroy(impactGO, 0.1f);
        }
        
    }
}
