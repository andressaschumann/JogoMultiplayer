using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour 
{

    private Rigidbody rb;

	public float sensitivityX = 8.0f;
	public float sensitivityY = 8.0f;
	private float minimumX = -360f;
	private float maximumX = 360f;
	private float minimumY = -80f;
	private float maximumY = 80f;
	private float rotationX = 0f;
	private float rotationY = 0f;
	public float moveSpeed = 6.0f;
	public GameObject PrefabGarage;
	public float timePreview;

	//private GameObject Line;
	 public Transform garagesp;

	public Camera playerCamera; 
	public Vector3 posPosition;
	bool jaSpawnou;

	// Use this for initialization
	void Start () {
		
		rb = GetComponent<Rigidbody>();
        if(!isLocalPlayer) {
            playerCamera.enabled = false;
            playerCamera.GetComponent<AudioListener>().enabled = false;
            return;
        }
    }
	[Command]
	void CmdSpawn(Vector3 posNew){
		

			GameObject garage =(GameObject ) Instantiate (PrefabGarage, posNew  , Quaternion.identity );
			NetworkServer.Spawn (garage);
			garage.GetComponent <Garage> ().playerL = this.transform;
		}

	void Update () {
        if(!isLocalPlayer) 
		{
            return;
        }

		timePreview += Time.deltaTime;

		if (!jaSpawnou) {
		
			if (Input.GetMouseButtonDown (0)) {
				Ray ray = playerCamera.ScreenPointToRay (new Vector3 (Input.mousePosition.x, Input.mousePosition.y ,Input.mousePosition.z));
				RaycastHit hit;	
				if (Physics.Raycast (ray, out hit, 100f)) {
					CmdSpawn (hit.point);
					jaSpawnou = true;
				}

			}
		}

		Vector3 cameraD = playerCamera.transform.forward;
		cameraD.y = transform.position.y;
		transform.LookAt (cameraD);


		Vector3 tmpVector = new Vector3(0f,0f,0f);
		if(Input.GetAxis("Vertical") > 0) {
			if (Input.GetAxis ("Horizontal") < 0) {
				tmpVector = ((rb.transform.right * Input.GetAxis("Horizontal")) + (rb.transform.forward * Input.GetAxis ("Vertical"))) * moveSpeed * 0.8f;
			} else if (Input.GetAxis ("Horizontal") > 0) {
				tmpVector = ((rb.transform.right * Input.GetAxis("Horizontal")) + (rb.transform.forward * Input.GetAxis ("Vertical"))) * moveSpeed * 0.8f;
			} else {
				tmpVector = rb.transform.forward * moveSpeed * Input.GetAxis("Vertical");
			}
		}else if (Input.GetAxis ("Vertical") < 0) {
			if (Input.GetAxis ("Horizontal") < 0) {
				tmpVector = ((rb.transform.right * Input.GetAxis("Horizontal")) + (rb.transform.forward * Input.GetAxis("Vertical"))) * moveSpeed * 0.8f;
			} else if (Input.GetAxis ("Horizontal") > 0) {
				tmpVector = ((rb.transform.right * Input.GetAxis("Horizontal")) + (rb.transform.forward * Input.GetAxis("Vertical"))) * moveSpeed * 0.8f;
			} else {
				tmpVector = rb.transform.forward * moveSpeed * Input.GetAxis("Vertical");
			}
		}else if(Input.GetAxis("Horizontal") > 0) {
			tmpVector = rb.transform.right * moveSpeed * Input.GetAxis("Horizontal");
		}else if (Input.GetAxis ("Horizontal") < 0) {
			tmpVector = rb.transform.right * moveSpeed * Input.GetAxis("Horizontal");
		}
		rb.velocity = new Vector3(tmpVector.x, rb.velocity.y, tmpVector.z);

        rotationX += Input.GetAxis("Mouse X") * sensitivityX;
        rotationY += Input.GetAxis("Mouse Y") * sensitivityY;
        rotationX = ClampAngle(rotationX, minimumX, maximumX);
        rotationY = ClampAngle(rotationY, minimumY, maximumY);

        rb.transform.rotation = Quaternion.Euler (new Vector3(0.0f, rb.transform.rotation.y+rotationX, 0.0f));
        playerCamera.transform.rotation = Quaternion.Euler (new Vector3(transform.rotation.x-rotationY, transform.rotation.y+rotationX, 0.0f));
    }

	public static float ClampAngle (float angle, float min, float max)
	{
		if (angle < -360F)
			angle += 360F;
		if (angle > 360F)
			angle -= 360F;
		return Mathf.Clamp (angle, min, max);
	}

}
