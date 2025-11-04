using UnityEngine;

public class RotateScript : MonoBehaviour, IInteractable
{
    private Transform StartPos;
    public Transform EndPos;
    public float MovementSpeed;

    public bool IsOpen = false;
    public bool IsMoving = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        IsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IInteractable.Interact()
    {
        Move();
        Debug.Log("Clicked");
    }

    public void Move()
    {
        Transform targetPos = EndPos;
        StartPos = transform;

     

        transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos.localPosition, Time.deltaTime * MovementSpeed);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, targetPos.localRotation, Time.deltaTime * MovementSpeed);

        float distance = Vector3.Distance(transform.localPosition, targetPos.localPosition);

        if (distance < 0.01f)
        {
            transform.localPosition = targetPos.localPosition;
            transform.localRotation = targetPos.localRotation;
            
        }
    }


}
