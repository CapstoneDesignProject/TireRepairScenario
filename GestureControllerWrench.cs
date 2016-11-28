using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using Leap;

public class GestureControllerWrench : MonoBehaviour
{

    Controller controller;
	CollisionAttachWrench wr;

    // Use this for initialization
    void Start()
    {
        controller = new Controller();
        controller.EnableGesture(Gesture.GestureType.TYPECIRCLE);

		wr = GameObject.Find("wrench").GetComponent<CollisionAttachWrench>();

    }

    void Update()
    {
 
        Frame frame = controller.Frame();

        if (wr.connect)
        {
            foreach (Gesture gesture in frame.Gestures())
            {
                switch (gesture.Type)
                {
                    case (Gesture.GestureType.TYPECIRCLE):
                        {
                            wr.circle_();
                            break;
                        }

                }
            }
        }



        }
    }


