using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    private List <IEnemy> enemies = new ();

    public void RegisterEnemies(IEnemy enemy)
    {
        enemies.Add(enemy);
    }

    public void SpreadAlert(Transform t)
    {
        foreach (var enemy in enemies)
        {
            enemy.AlertSpread(t);
        }
    }
}
