using UnityEngine;
using System.Collections;

public class tireAttach : MonoBehaviour {

    public bool connect_t;
    public int cc;

	Vector3 newPosition;
	Vector3 newRotation;

	Vector3 newSize;
	GameObject att;

	BoxCollider bc;



	// Use this for initialization
	void Start () {
		connect_t = false;
		cc = 0;

		newPosition = new Vector3(1.94f, -1.86f, -2.44f);
		newRotation = new Vector3(0, 177.7558f, 0);
		newSize = new Vector3(0.36f, 0.32f, 0.26f);

		att = GameObject.Find("bolt_att");
		bc = this.gameObject.GetComponent<BoxCollider>();
	}
	
	// Update is called once per frame
	void Update () {
       
        if (connect_t)
        {
            cc++;
			this.transform.localPosition = newPosition;
			this.transform.localRotation = Quaternion.Euler(newRotation);

            Destroy(bc);
            if (cc == 1)
            {
                att.AddComponent<BoxCollider>();
                att.GetComponent<BoxCollider>().isTrigger = true;
				att.GetComponent<BoxCollider> ().size = newSize;
            }
        }
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "tire")
        {
            connect_t = true;

        }
    }
}
