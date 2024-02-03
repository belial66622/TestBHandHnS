using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Mengatur object yang bisa dimakan.
/// </summary>
public interface IEatObejct
{
    /// <summary>
    /// Ketika bertabrakan dengan hole.
    /// </summary>
    void Collide();

    /// <summary>
    /// ketika kelur dari hole.
    /// </summary>
    void OutCollide();
}
