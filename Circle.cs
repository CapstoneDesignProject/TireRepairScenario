using UnityEngine;
using System.Collections;

public class Circle : MonoBehaviour
{
    public int rotate;
	Vector3 circleRotate;
	CollisionSteer cs;
   
    // Use this for initialization
    void Start()
    {
		rotate = 0;
		circleRotate = new Vector3(30, 0, 0);
		cs = GameObject.Find("steeringwheels").GetComponent<CollisionSteer>();
    }

    public void circle()
    {
            cs.connect = false;
			transform.Rotate(circleRotate);
        
    }

    // Update is called once per frame
    void Update()
    {

    }
}