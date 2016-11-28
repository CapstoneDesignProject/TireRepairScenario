using UnityEngine;
using System.Collections;

public class CollisionAttachWrench : MonoBehaviour
{
    public int cnt = 0;
    public bool connect = false;
    public bool drop_ = false;
    public bool connect2 = false; //bolt2에 붙으면

    public GameObject bolt2 ;
    CollisionAttach jack;
	DetachBolt bolt;
	BoxCollider bc;

	Vector3 newPosition;
	Vector3 newRotate;

    void Start()
    {
		cnt = 0;
		connect = false;
		connect2 = false;
		drop_ = false;

		bolt2 = GameObject.Find("bolt2");
		bolt = GameObject.Find("bolt").GetComponent<DetachBolt>();
		jack = GameObject.Find("jacks").GetComponent<CollisionAttach>();
		bc = jack.GetComponent<BoxCollider>();  

		newPosition = new Vector3(-1.92f, -1.542f, -0.556f);
		newRotate = new Vector3(270.56f, 225.60f, 73.76f);

    }
    public void circle_(){
  
        cnt++;
        
        if (cnt > 60)
        {
			drop_ = true;

            drop();
			bolt.detachBolt();
        }

    }

    public void drop()
    {

		this.transform.localPosition = newPosition;
		transform.rotation = Quaternion.Euler(newRotate);

    }
    // Update is called once per frame
    void Update()
    {

        Vector3 v;//Vector3 변수를 선언  
        v = transform.position;
        if ((transform.position.x >= -4.0f && transform.position.x <= -3.0f) && (transform.position.y >= 0.0f && transform.position.y <= 1.0f) && (transform.position.z >= -102.0f && transform.position.z <= -100.0f))
        {
            connect = true;
        }
        //해당 오브젝트의 포지션값을 v에 넣고
        if (connect == true && drop_ == false)
        {
            Vector3 v2;
            v2 = bolt2.transform.position;
            transform.position = v2;
            this.GetComponent<Rigidbody>().isKinematic = true;
            Destroy(bc);//jack에 있는 콜라이더 제거
        
           
        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "wheel")
        {
            connect = true;
        }

    }
}