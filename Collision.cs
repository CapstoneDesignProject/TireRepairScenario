using UnityEngine;
using System.Collections;

public class Collision : MonoBehaviour
{
    int cnt;
    public bool connect;
	Vector3 newPosition;

    // Use this for initialization
    void Start()
    {
		cnt = 0;
		connect = false;
		newPosition = new Vector3 (-3.5f, 0.8f, -101.5f);

    }

    // Update is called once per frame
    void Update()
    {
        if (connect)
		{
			transform.position = newPosition;
            GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        }

    }

    void OnTriggerEnter(Collider other)
    {
        cnt++;

        if (other.transform.tag == "jack" && cnt==1)
        {
            connect = true;
        }



    }
}