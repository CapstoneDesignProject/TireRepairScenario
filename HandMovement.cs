using UnityEngine;
using System.Collections;

public class HandMovement : MonoBehaviour {

	float distanceFromCamera = 3f;
	Vector3 centerPos;

	private Transform tr;

	private float speed = 2.0f;
	private float zoomSpeed = 2.0f;

	public float minX = -360.0f;
	public float maxX = 360.0f;

	public float minY = -45.0f;
	public float maxY = 45.0f;

	public float sensX = 100.0f;
	public float sensY = 100.0f;

	float rotationY = 0.0f;
	float rotationX = 0.0f;

	void Start () {
		tr = GetComponent<Transform> ();
	}

	void Update () {
		centerPos = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.1f, distanceFromCamera));
		tr.position = centerPos;

		rotationX += Input.GetAxis ("Mouse X") * sensX * Time.deltaTime;
		rotationY += Input.GetAxis ("Mouse Y") * sensY * Time.deltaTime;
		rotationY = Mathf.Clamp (rotationY, minY, maxY);
		tr.localEulerAngles = new Vector3 (-rotationY, rotationX, 0);
	}
}
