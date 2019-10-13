using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStarter : MonoBehaviour {

    public GameObject gameManager;
    public int level = 5;
    public bool isHit = false;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (isHit == true)
        {
            Game_Manager targetScript = gameManager.GetComponent<Game_Manager>();
            targetScript.SetupScene(level);
            isHit = false;
        }

    }

    public void StartLevel ()
    {
        if (isHit == false)
        {
            Game_Manager targetScript = gameManager.GetComponent<Game_Manager>();
            targetScript.SetupScene(level);
            isHit = true;
        }
    }
}
