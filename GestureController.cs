using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class GestureController : MonoBehaviour
{

    Controller controller;
    public int c;
    public int car_up;

	CollisionSteer sw;
	CollisionAttach jack;
	CollisionAttachWrench wr;

	Circle cir;
	JackUp ju;
	CarUp cu;


    // Use this for initialization
    void Start()
    {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);
        controller.EnableGesture(Gesture.GestureType.TYPESWIPE);


		sw = GameObject.Find("steeringwheels").GetComponent<CollisionSteer>(); //cs
		jack = GameObject.Find("jacks").GetComponent<CollisionAttach>();//cs1
		wr = GameObject.Find("wrench").GetComponent<CollisionAttachWrench>();//cs2

		cir = GameObject.Find("쪼꼬").GetComponent<Circle>();
		ju = GameObject.Find("jacks").GetComponent<JackUp>();
		cu = GameObject.Find("CARMODEL").GetComponent<CarUp>();

		c = 1; //ccccc
		car_up = 0;
    }

    void Update()
    {
    
        Frame frame = controller.Frame();


        if (sw.steer_cir && jack.jack_cir)
        {
            foreach (Gesture gesture in frame.Gestures())
            {
                switch (gesture.Type)
                {
                    case (Gesture.GestureType.TYPECIRCLE):
                        {
                            if (wr.connect)
                            {
                                wr.circle_();
                                break;

                            }
                            if (car_up <= 12)
                            {
                                cir.circle();
                                ju.Jackup();
                                cu.Carup();
                                car_up++;
                                break;
                            }
                            break;
                        }

                }


            }
        }
    }
}

    


