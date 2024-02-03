using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// Scene change pada button.
/// </summary>
public class SceneChange : MonoBehaviour
{
    public void MoveScene(string scenename)
    {
        SceneManager.LoadScene(scenename);
    }
}
