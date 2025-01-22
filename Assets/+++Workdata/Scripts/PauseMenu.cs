using UnityEngine;
//using UnityEngine.InputSystem;
public class PauseMenu : MonoBehaviour
{
    //public GameInput inputActions;
    public GameObject pauseMenu;
    private bool isPaused = false;
  


    public void PauseGame()  // PauseMenu anmachen
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
  
    void Update() // Taste funktionieret
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }


    public void ResumeGame() //PauseMenu ausmachen
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
}