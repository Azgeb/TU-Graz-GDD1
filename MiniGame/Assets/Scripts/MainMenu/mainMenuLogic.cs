using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenuLogic : MonoBehaviour
{
    public void StartGame(){
        SceneManager.LoadScene("Game");
    }

    public void Info(){
        SceneManager.LoadScene("Info");
    }

    public void Controls(){
        SceneManager.LoadScene("Controls");
    }

    public void MainMenu(){
        SceneManager.LoadScene("Main");
    }
}
