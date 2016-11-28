using UnityEngine;
using System.Collections;

public class JackUp : MonoBehaviour {
    
	Vector3 newScale;

	void Start () {
		newScale = new Vector3(0, 0, 0.001f);
	}

    public void Jackup()
    {
       
		transform.localScale += newScale;

    }

	void Update () {
	
	}
}
