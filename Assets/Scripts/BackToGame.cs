using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToGame : MonoBehaviour
{
    public void LoadGame()
    {
        Cursor.lockState = CursorLockMode.None;  
        Cursor.visible = true;  
        SceneManager.LoadScene(1);  
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {  
            LoadGame();  
        }
    }
}
