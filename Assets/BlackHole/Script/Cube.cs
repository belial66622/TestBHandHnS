using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Untuk cube.
/// </summary>
public class Cube : MonoBehaviour, IEatObejct
{
    /// <summary>
    /// variabel yang nantinya akan menyimpan Collider dari cube.
    /// </summary>
    private Collider coll =null;

    /// <summary>
    /// variabel yang nantinya akan menyimpan Rigidbody dari cube.
    /// </summary>
    private Rigidbody rb = null;

    /// <summary>
    /// Digunakan untuk coroutine agar bisa mengecek coroutine yang sedang berjalan.
    /// </summary>
    Coroutine delay;

    /// <summary>
    /// Mengecek apakah player sedang collide atau tidak.
    /// </summary>
    bool IsCollide= false;
    private void Awake()
    {
        coll= GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
    }
    public void Collide()
    {
        if (IsCollide) return;

        coll.isTrigger = true;
        rb.isKinematic= false;

        if (delay == null)
            delay = StartCoroutine(Delay(true));
    }

    public void OutCollide()
    {
        if (!IsCollide) return;
        coll.isTrigger = false;
        rb.isKinematic = true;
        
        if (delay == null)
            delay = StartCoroutine(Delay(false));

    }


    IEnumerator Delay(bool condition)
    {
        yield return new WaitForSeconds(0.1f);
        
        IsCollide = condition;

        delay = null;
    }
}
