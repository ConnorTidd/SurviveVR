using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	// Use this for initialization
    public int score;

	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        t.text = "s";

    }
}
