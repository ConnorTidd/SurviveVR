using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {

    public float moveForce = 1f;
    public Transform[] target;
    private int current;

    //private Rigidbody rBody;
	// Use this for initialization
	void Start () {
       // rBody = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
        if (transform.position != target[current].position)
        {
            Vector3 pos = Vector3.MoveTowards(transform.position, target[current].position, moveForce * Time.deltaTime);
            GetComponent<Rigidbody>().MovePosition(pos);
        } else if (current <= target.Length)  {
            current = (current + 1);
        }
	}


}
