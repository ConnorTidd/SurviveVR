using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour {

    public int health;
    public bool isHit;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Debug.Log("dead");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name, LoadSceneMode.Single);
            //Destroy(gameObject);


        }
    }

    public void Hit(int damage)
    {
        
        health -= damage;
        


        
        isHit = true;

        Debug.Log(health);
    }
}
