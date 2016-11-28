using UnityEngine;
using System.Collections;

public class DetachBolt : MonoBehaviour
{
	public bool boltState;
	public bool connectBolt;

	int cnt;
	int cnt2;

	Vector3 newColliderSize;
	Vector3 newPosition;
	Vector3 newRotation;

	GameObject wrench;
	CollisionAttachWrench cw;

	void Start()
	{
		boltState = false;
		connectBolt = false;
		cnt = 0;
		cnt2 = 0;

		newColliderSize = new Vector3(0.33f ,0.44f, 0.42f);
		newPosition = new Vector3(2.193f,-1.847f,-2.423f);
		newRotation = new Vector3(355.376f, 10.496f, 359.7095f);

		wrench = GameObject.Find("wrench");
		cw = GameObject.Find ("wrench").GetComponent<CollisionAttachWrench> ();

	}
	public void detachBolt()
	{
		boltState = true;
	}
	// Update is called once per frame
	void Update()
	{
		DetachTire dropTire = GameObject.Find("tire").GetComponent<DetachTire>();

		if (boltState)
		{ 
			cnt++;
			if (cnt == 1)
			{        
				this.gameObject.AddComponent<BoxCollider>();
				this.gameObject.AddComponent<Rigidbody>();
				this.GetComponent<Rigidbody>().useGravity = true;
				this.GetComponent<BoxCollider>().size = newColliderSize;
				dropTire.tireState = true;
			}
		}

		if (connectBolt)
		{
			this.transform.localPosition = newPosition;
			this.transform.localRotation = Quaternion.Euler(newRotation);
			wrench.GetComponent<Rigidbody>().isKinematic = false;

			if (cnt2 != 1)
			{
				cnt2++;
				cw.connect = false;
				cw.drop_ = false;
				cw.cnt = 0;
			}
		} 
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag == "bolt")
		{
			connectBolt = true;
		}
	}
}