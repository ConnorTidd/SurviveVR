using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileDespawn : MonoBehaviour {

    public int damage = 5;

    public GameObject impactEffect;
    public Transform projectileSpawn;
    
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Destroy(gameObject, 2f);
    }

    void OnTriggerEnter(Collider col)
    {

        if (col.GetComponent<EnemyStats>())
        {
            GameObject impactGO = Instantiate(impactEffect, projectileSpawn.position, Quaternion.LookRotation(projectileSpawn.forward));
            Destroy(impactGO, 1f);

            EnemyStats enemyStats = col.GetComponent<EnemyStats>();
            enemyStats.Hit(damage);


            PlayerStats playerStats = col.GetComponent<PlayerStats>();
            playerStats.Hit(damage);






            //PARTICLE EFFECT
        }
        else if (col.GetComponent<GameStarter>())
        {
            
            GameStarter starter = col.GetComponent<GameStarter>();
            starter.StartLevel();
        }

    }

    
}
