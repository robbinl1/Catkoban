using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    Scene _Scene;
    void Awake()
    {
        DontDestroyOnLoad(this);
        if (FindObjectsOfType(GetType()).Length > 1)
            //Destroy any copies
            Destroy(gameObject);
    }
    public void NewLevel(bool reset)
    {
        _Scene = SceneManager.GetActiveScene();
        if (reset)
        {
            SceneManager.LoadScene(_Scene.name);
            return;
        }
        if (_Scene.name == "MainMenu")
        {
            SceneManager.LoadScene("Level1");
        }
        else if (_Scene.name == "Level1")
        {
            SceneManager.LoadScene("Level2");
        }
        else if (_Scene.name == "Level2")
        {
            SceneManager.LoadScene("Level3");
        }
        else if (_Scene.name == "Level3")
        {
            SceneManager.LoadScene("EndScreen");
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }

    }
}
