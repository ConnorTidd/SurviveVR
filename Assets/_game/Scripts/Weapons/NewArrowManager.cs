using UnityEngine;
using System.Collections;

public class NewArrowManager : MonoBehaviour {

	public static NewArrowManager Instance;

	public GameObject oculusRight;
    public GameObject arrowHolder;

	private GameObject currentArrow;

	public GameObject stringAttachPoint;
	public GameObject arrowStartPoint;
	public GameObject stringStartPoint;

	public GameObject arrowPrefab;

	private bool isAttached = false;

	void Awake() {
		if (Instance == null)
			Instance = this;
	}

	void OnDestroy() {
		if (Instance == this)
			Instance = null;
	}

	// Use this for initialization
	void Start () {
        
    }


	void Update() {

		SpawnArrow ();

        float dist = (stringStartPoint.transform.position - oculusRight.transform.position).magnitude;
        Debug.Log(dist);
        if (dist < 0.1 && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
        {
            AttachBowToArrow();
        }

        PullString ();
        
        

    }

	private void PullString() {
		if (isAttached) {
			float dist = (stringStartPoint.transform.position - oculusRight.transform.position).magnitude;
           
			stringAttachPoint.transform.localPosition = stringStartPoint.transform.localPosition  + new Vector3 (0f, .3f * dist, 0f);

            //var device = SteamVR_Controller.Input((int)oculusRight.index);
            if (OVRInput.GetUp(OVRInput.Button.SecondaryIndexTrigger) && dist > 0.1)
            {
				Fire ();
                
            }
            
		}
	}

	private void Fire() {
		float distance = (stringStartPoint.transform.position - oculusRight.transform.position).magnitude;
     

        currentArrow.transform.parent = null;
		currentArrow.GetComponent<Arrow> ().Fired ();
        
        Rigidbody r = currentArrow.GetComponent<Rigidbody> ();
		r.velocity = -currentArrow.transform.up * 40f * distance;
        
       // r.useGravity = true;

        currentArrow.GetComponent<Collider> ().isTrigger = true;

		stringAttachPoint.transform.position = stringStartPoint.transform.position;

		currentArrow = null;
		isAttached = false;
	}

	private void SpawnArrow() {
		if (currentArrow == null) {
			currentArrow = Instantiate (arrowPrefab);
			currentArrow.transform.parent = arrowHolder.transform;
			currentArrow.transform.localPosition = new Vector3 (0f, 0f, 0f);
			currentArrow.transform.localRotation = Quaternion.identity;
            
        }
	}

	public void AttachBowToArrow() {
		currentArrow.transform.parent = stringAttachPoint.transform;
		currentArrow.transform.position = arrowStartPoint.transform.position;
		currentArrow.transform.rotation = arrowStartPoint.transform.rotation;

		isAttached = true;
	}
}