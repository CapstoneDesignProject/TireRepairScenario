﻿using UnityEngine;
using System.Collections;

public class CarUp : MonoBehaviour {

    public int upCnt;
	Vector3 bonnetNewRotate;

	void Start () {
	
		upCnt = 0;
		bonnetNewRotate = new Vector3 (0, 0, 0.2f);
	}

    public void Carup()
    {
       if(upCnt <= 12)
        {
			transform.Rotate(bonnetNewRotate);
            upCnt++;
        }
    }
	// Update is called once per frame
	void Update () {
	
	}
}
