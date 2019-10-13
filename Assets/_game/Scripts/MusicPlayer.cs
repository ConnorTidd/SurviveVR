using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicPlayer : MonoBehaviour {

    // Use this for initialization
    public AudioClip clip;
    void Start () {
        Debug.Log("playing");
        AudioSource.PlayClipAtPoint(clip, new Vector3(0, 0, 0));
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
