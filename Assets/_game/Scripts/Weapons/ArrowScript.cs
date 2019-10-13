using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowScript : MonoBehaviour {

    public int damage;
    public GameObject impactEffect;
    public Transform arrowspawn;

    void OnTriggerEnter (Collider col)
    {
        Debug.Log("collider found");
        
            if(col.GetComponent<EnemyStats>())
            {
                 Debug.Log("enemy collider found");
                EnemyStats stats = col.GetComponent<EnemyStats>();
                stats.Hit(damage);

                GameObject impactGO = Instantiate(impactEffect, arrowspawn.position, Quaternion.LookRotation(arrowspawn.forward));
                Destroy(impactGO, 0.1f);
        }
        
    }
}
