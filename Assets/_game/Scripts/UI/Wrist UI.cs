using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WristUI : MonoBehaviour {

    public int score;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
        TextMesh t = (TextMesh)gameObject.GetComponent(typeof(TextMesh));
        t.text = "s";
    }
}
