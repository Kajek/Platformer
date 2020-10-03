using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartFirstLevel()
    {
        SceneManager.LoadScene(2);        
    }
    public void StartNewGame()
    {
        SceneManager.LoadScene(2);
        GameMaster.GameSession.ResetGameSession();
        GameMaster.PlayerHealth.ResetPlayerHealth();
        GameMaster.Player.ResetPlayer();
        SceneManager.LoadScene(1);
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene(0);
        
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
