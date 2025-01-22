using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    private PlayerController player;
    private DialogueController dialogueController;

    public Button lastSelectable;
    #region Unity Event Functions

    private void Awake()
    {
        player = FindObjectOfType<PlayerController>();
        dialogueController = FindObjectOfType<DialogueController>();
    }

    private void OnEnable()
    {
        DialogueController.DialogueClosed += EndDialogue;
    }

    private void Start()
    {
        if(player)
            EnterPlayMode();
    }

    private void OnDisable()
    {
        DialogueController.DialogueClosed -= EndDialogue;
    }

    #endregion

    #region Modes

    public void EnterPlayMode()
    {
        Time.timeScale = 1;
        // In the editor: Unlock with ESC.
        //Cursor.lockState = CursorLockMode.Locked;
        player.EnableInput();
    }

    private void EnterDialogueMode()
    {
        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.Locked;
        player.DisableInput(); 
    }

    #endregion

    public void StartDialogue(string dialoguePath) // Dialog aufrufen mit einem Path
    {
        EnterDialogueMode();
        dialogueController.StartDialogue(dialoguePath);
    }

    private void EndDialogue() // Damit ich meinen Player nicht bwegen kann
    {
        EnterPlayMode();
    }

    public void SetLastSelectable()
    {
        SetSelectable(lastSelectable);
    }
    public void SetSelectable(Button newSelactable) // Wenn man multiple choices auswählen kann
    {
        Selectable newSelectable;
        lastSelectable = newSelactable;
        newSelectable = newSelactable;

        //newSelactable.Select();
        StartCoroutine(DelayNewSelectable(newSelectable));
    }

    public void ExitMenu()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;
    }

    IEnumerator DelayNewSelectable(Selectable newSelectable)
    {
        yield return null;
        newSelectable.Select();
    }
}

