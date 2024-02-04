using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IEnemy
{

     bool Alert { get; set; }
    void Spreadcommand();

    void AlertSpread(Transform t);
}
