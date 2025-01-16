using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    public void Button_OpenOptionsMenu() // wenn es um Buttons geht, am besten immer mit Button anfangen(Button schreiben)
    {
        mainMenu.SetActive(false);
        optionsMenu.SetActive(true);
    }
    
    public void Button_OpenMainMenu()
    {
        mainMenu.SetActive(true);
        optionsMenu.SetActive(false);
    }

    public void Button_NewGame()
    {
        SceneManager.LoadScene(1);
    }

}
