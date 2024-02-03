using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Untuk hole.
/// </summary>
public class Hole : MonoBehaviour
{
    /// <summary>
    /// Menyimpan transform.
    /// </summary>
    Transform t = null;

    /// <summary>
    /// Speed untuk player.
    /// </summary>
    float speed = 3f;

    private void Awake()
    {
        t= transform;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            t.position += speed* Vector3.forward * Time.deltaTime; 
        }

        else if (Input.GetKey(KeyCode.S))
        {
            t.position += speed * Vector3.back * Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A))
        {
            t.position += speed * Vector3.left * Time.deltaTime;
        }

        else if (Input.GetKey(KeyCode.D))
        {
            t.position += speed * Vector3.right * Time.deltaTime;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out IEatObejct obj))
        {
            obj.Collide();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out IEatObejct obj))
        {
            obj.OutCollide();
        }
    }
}
