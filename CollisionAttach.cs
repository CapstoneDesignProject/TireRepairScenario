using UnityEngine;
using System.Collections;

public class CollisionAttach : MonoBehaviour {

	public bool connect = false;
    public bool jack_cir = false;

	Vector3 newPosition;
	Vector3 newRotation;

	// Use this for initialization
	void Start () {

		newPosition = new Vector3 (-3.5f, 0.8f, -101.5f);
		newRotation = new Vector3 (270, 30, 0);

	}
	
	// Update is called once per frame
	void Update () {
        
		Vector3 v;//Vector3 변수를 선언  
        v = transform.position;
        if ((transform.position.x >= -4.0f && transform.position.x <= -3.0f) && (transform.position.y >= 0.0f && transform.position.y <= 1.0f) && (transform.position.z >= -102.0f && transform.position.z <= -100.0f))
        {
            connect = true;
        }
            //해당 오브젝트의 포지션값을 v에 넣고
        if(connect == true)
        {
            jack_cir = true;
			transform.position = newPosition;
			transform.rotation = Quaternion.Euler(newRotation);
            this.GetComponent<Rigidbody>().isKinematic = true;
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }
        
	
	}


	
}