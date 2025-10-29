using UnityEngine;
using UnityEngine.Events;

public class CodeUnlock : MonoBehaviour
{
    [Header("Code Settings")]
    public string CorrectCode;
    private bool unlocked = false;

    public GameObject CodeUi;
    public BasicPlayerController playerController;

    private void Start()
    {
        gameObject.SetActive(true);
    }

    public void EnterCode(string playerInput)
    {
        if (unlocked)
        {
            return;
        }

        if (playerInput == CorrectCode)
        {
            unlocked = true;
            Debug.Log("Unlocked");
            gameObject.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            playerController.CanMove = true;
            CodeUi.SetActive(false);
        }

        else
        {
            Debug.Log("Incorrect");
            gameObject.SetActive(true);

        }
    }
}
