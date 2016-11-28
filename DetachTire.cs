using UnityEngine;
using System.Collections;

public class DetachTire : MonoBehaviour
{
	public bool tireState;
	public bool connectTire;
	int cnt;

	Vector3 newPosition;
	Tire tire;

	void Start()
	{
		tireState = false;
		connectTire = false;
		cnt = 0;

		newPosition = new Vector3 (-3.5f, 1.3f, -102.4f);

		tire = GameObject.Find("tire2").GetComponent<Tire>();
	}

	public void detachTire()
	{
		transform.position = newPosition;
		GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
	}

	// Update is called once per frame
	void Update()
	{ 
		if (tireState)
		{
			cnt++;
			if (cnt == 1)
			{
				this.gameObject.AddComponent<BoxCollider>();
				this.GetComponent<Rigidbody>().isKinematic = false;
				this.GetComponent<BoxCollider>().isTrigger = false;
				tire.putTire = true;
			}
		}
		if (this.transform.localPosition.x >= 1.9f)
			this.GetComponent<Rigidbody>().useGravity = true;    
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "tire")
		{
			connectTire = true;
		}
	}
}