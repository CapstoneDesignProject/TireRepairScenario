using UnityEngine;
using System.Collections;

public class CollisionSteer : MonoBehaviour
{
	public bool connect;
    public bool steer_cir;
    GameObject jacks;
    GameObject steeringwheels;

	Vector3 newPosition;
	Vector3 newRotation;
	Vector3 newScale;
    
    int j;
	public GameObject ssmall;

    // Use this for initialization
    void Start()
    {
		connect = false;
		steer_cir = false;

		j = 0;
		ssmall = GameObject.Find("쪼꼬");

		newPosition = new Vector3(-7.15f, 1.96f, -0.38f);
		newRotation = new Vector3(80.9f, 77.61f, 225.45f);
		newScale = new Vector3(0, 0, 0.001f);


    }
    // Update is called once per frame
    void Update()
    {
       
        if (connect)
        {
            steer_cir = true;
           
			transform.localPosition = newPosition;
			transform.rotation = Quaternion.Euler(newRotation);
            
           GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
           this.transform.parent = ssmall.transform;
           this.GetComponent<Rigidbody>().isKinematic = true;
           Destroy(this.GetComponent<BoxCollider>());
        }
    }

   public  void Scale()
    {
		transform.localScale -= newScale;

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "CS")
        {
            connect = true;
        }
    }
}