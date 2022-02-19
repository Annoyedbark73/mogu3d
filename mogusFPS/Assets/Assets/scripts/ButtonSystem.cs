using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonSystem : MonoBehaviour
{
    public void QuitButton()
    {
        Application.Quit();
        Debug.LogWarning("Game Closed");
    }

    public void PlayGame()
    {
        SceneManager.LoadSceneAsync("testmap");
        Debug.Log("testmap loaded");
    }
   

    // Update is called once per frame
    void Update()
    {
        
    }
}
