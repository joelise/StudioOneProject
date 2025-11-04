using UnityEngine;

public class Door : MonoBehaviour, IInteractable
{
    public GameObject CodeUi;
    public BasicPlayerController playerController;
    public GameObject door;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IInteractable.Interact()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        playerController.CanMove = false;
        CodeUi.SetActive(true);
        door.SetActive(false);
    }
}
