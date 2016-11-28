using UnityEngine;
using System.Collections;

public class Rotate : MonoBehaviour {

	Vector3 newRotate;

	// Use this for initialization
	void Start () {
	
		newRotate = new Vector3(1, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		gameObject.transform.Rotate(newRotate);
	}
}
