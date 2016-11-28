using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

	private float speed = 2.0f;
	//private float zoomSpeed = 2.0f;

	private float h = 0.0f;
	private float v = 0.0f;

	private Transform tr;

	public float minX = -360.0f;
	public float maxX = 360.0f;
	
	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;
	
	float rotationY = 0.0f;
	float rotationX = 0.0f;

	void Start() {
		tr = GetComponent<Transform> ();
	}

	void Update () {
		// Keyboard input for camera movement
		h = Input.GetAxis ("Horizontal");
		v = Input.GetAxis ("Vertical");

		// Calculate camera move direction
		Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);
		tr.Translate (moveDir * Time.deltaTime * speed, Space.Self);

		/* Mouse scroll action
		float scroll = Input.GetAxis("Mouse ScrollWheel");
		tr.Translate(0, scroll * zoomSpeed, scroll * zoomSpeed, Space.World);*/

		// Camera focus rotation by mouse
		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		tr.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);

	}
}
