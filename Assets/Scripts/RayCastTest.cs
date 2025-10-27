using UnityEngine;

public class RayCastTest : MonoBehaviour, IInteractable
{
    void IInteractable.Interact()
    {
        Debug.Log("Hit");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
