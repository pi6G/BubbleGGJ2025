using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.SceneManagement;

public class BasicSceneScripts : MonoBehaviour
{
    public void ChangeScene(string str)
    {
        SceneManager.LoadScene(str);
    }
}
