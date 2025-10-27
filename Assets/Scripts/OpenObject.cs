using UnityEngine;

public class OpenObject : MonoBehaviour, IInteractable
{
    public Transform startPos;
    public Vector3 NewPos;
   
    void IInteractable.Interact()
    {
        transform.Translate(NewPos);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPos = transform;
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
