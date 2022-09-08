using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
    [SerializeField] float speed = 10f;
    [SerializeField] GameObject light;
    float horizontalInput;
    float verticalInput;
    Vector2 camPos;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        light.transform.position = transform.position + new Vector3(0, 0, 10f);
    }

    private void LateUpdate()
    {
        camPos = new Vector2 (horizontalInput, verticalInput) * speed;
        transform.Translate(camPos);
    }
}
