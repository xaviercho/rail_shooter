using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class sceneloader : MonoBehaviour {


    // Use this for initialization
    void Start()
    {
        Invoke("LoadFirstScene", 1.4f);
        Invoke("LoadLastScene", 5f);

    }

    void LoadFirstScene()
    {
        SceneManager.LoadScene(1);
    }

    void LoadLastScene()
    {
        SceneManager.LoadScene(2);
    }
}
