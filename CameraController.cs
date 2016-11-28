using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour
{
    private Vector2 startPos;

    // 초기화 함수
    void Start()
    {
    }

    // 프레임마다 계속 호출
    void Update()
    {
        // 마우스 이동
        if (Input.GetMouseButtonDown(0))
        {
            startPos = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            float mouseMoveX = Input.mousePosition.x - startPos.x;
            float mouseMoveY = Input.mousePosition.y - startPos.y;
            startPos = Input.mousePosition;

            transform.Rotate(-mouseMoveY * 0.1f, 0, 0);
            transform.Rotate(0, mouseMoveX * 0.1f, 0, Space.World);
        }

        // 전후좌우 이동
        float speed = 5.0f;
        float amtMove = speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.Q)) transform.Translate(Vector3.down * amtMove);
        else if (Input.GetKey(KeyCode.E)) transform.Translate(Vector3.up * amtMove);
        else
        {
            float ver = Input.GetAxis("Vertical");// 전후 이동 방향(벡터)
            float hor = Input.GetAxis("Horizontal");// 좌우 이동 방향(벡터)

            transform.Translate(Vector3.forward * ver * amtMove);// 전후진
            transform.Translate(Vector3.right * hor * amtMove);// 좌우 이동
        }

        if (Input.GetKey(KeyCode.M))
        {
            transform.Rotate(0.1f, 0, 0);
            transform.Rotate(0, 0.1f, 0, Space.World);
        }
    }
}