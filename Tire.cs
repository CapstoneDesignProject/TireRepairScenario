using UnityEngine;
using System.Collections;

public class Tire : MonoBehaviour
{
	public bool putTire;
	int cnt;

	Vector3 newSize;
	Vector3 newCenter;

	// Use this for initialization
	void Start()
	{
		putTire = false;
		cnt = 0; 

		newSize = new Vector3(1.74f, 1.16f, 1.13f);
		newCenter = new Vector3(0.62f, -1.91f, -2.73f);

	}
	// Update is called once per frame
	void Update()
	{
		if (putTire)
		{
			cnt++;
			if (cnt == 1)
			{
				this.gameObject.AddComponent<BoxCollider>();
				GetComponent<BoxCollider> ().size = newSize;
				GetComponent<BoxCollider> ().center = newCenter;
				GetComponent<BoxCollider>().isTrigger = true;
			}
		}
	}
}