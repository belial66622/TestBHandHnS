using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class Movement : MonoBehaviour
{
    Transform t = null;

    Vector3 position = Vector3.zero;

    Vector3 dir = Vector3.zero;

    float speed = 5;

    private void Awake()
    {
        t = transform;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        position = Vector3.zero;

        if (Input.GetKey(KeyCode.W))
        {
            position += Vector3.forward; 
        }

        else if (Input.GetKey(KeyCode.S))
        {
            position += Vector3.back; 
        }

        if (Input.GetKey(KeyCode.A))
        {
            position += Vector3.left;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            position += Vector3.right;
        }

        t.position += speed * Time.deltaTime *position;

        if (position != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                Quaternion.LookRotation(position),
                Time.deltaTime * 5
            );
        }
    }
}
