using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class thanks : MonoBehaviour
{


    // Use this for initialization
    void Start()
    {
        Invoke("LoadLastScene", 1f);

    }

    void LoadLastScene()
    {
        SceneManager.LoadScene(2);
    }
}
