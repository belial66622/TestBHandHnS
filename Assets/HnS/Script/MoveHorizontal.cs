using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveHorizontal : MonoBehaviour
{
    Vector3 position1= Vector3.zero;
    [SerializeField]
    Vector3 position2= Vector3.zero;

    bool isBackPatrol =false;

    private void Start()
    {
        position1= transform.position;
    }

    private void FixedUpdate()
    {
        if (!isBackPatrol)
        {
            transform.position = Vector3.MoveTowards(transform.position, position2, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, position2) <= .5f)
            {
                isBackPatrol = true;
            }
            if (transform.position.x < position2.x)
            {
                rotate(Vector3.right);
            }
            else
            {
                rotate(Vector3.left);
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, position1, 1 * Time.deltaTime);
            if (Vector3.Distance(transform.position, position1) <= .5f)
            {
                isBackPatrol = false;
            }

            if (transform.position.x < position1.x)
            {
                rotate(Vector3.right);
            }
            else 
            {
                rotate(Vector3.left);
            }
        }

    }

    void rotate(Vector3 dir)
    {
        transform.rotation = Quaternion.Slerp(
        transform.rotation,
            Quaternion.LookRotation(dir),
            Time.deltaTime * 5
        );
    }
}
