using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Reference to the UI
    public GameObject GameOverUI;
    public GameObject MainMenuUI;
    public void PlayGame()
    {
        //Loads the next scene (The game level)
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        //If you want to load a specific scene, you use its name instead.
        //SceneManager.LoadScene("Level01");
    }
    public void CreditsScene()
    {
        //Load the credits scene
        SceneManager.LoadScene("Credits");
    }
    public void QuitGameUI()
    {
        //Disable the Menu UI and enable the Game over UI
        MainMenuUI.SetActive(false);
        GameOverUI.SetActive(true);
    }
    public void QuitGame()
    {
        //Quit the Game()
        Application.Quit();
    }
}
