using UnityEngine;

public class OpenObject : MonoBehaviour, IInteractable
{
    public Transform StartPos;
    public Transform EndPos;
    public float MovementSpeed;

    public bool IsOpen = false;
    public bool IsMoving = false;
   
   
    void IInteractable.Interact()
    {
        if (IsOpen == false)
        {
            IsOpen = true;
        }
        else
        {
            IsOpen = false;
        }

        IsMoving = true;

        //transform.Translate(NewPos);
        //gameObject.SetActive(false);
        Debug.Log("Opened");
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
       
        //gameObject.SetActive(true);
       
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    public void Move()
    {
        if (IsMoving)
        {
            Transform targetPos;

            if (IsOpen)
            {
                targetPos = EndPos;
            }
            else
            {
                targetPos = StartPos;
            }

            transform.localPosition = Vector3.Lerp(transform.localPosition, targetPos.localPosition, Time.deltaTime * MovementSpeed);
            transform.localRotation = Quaternion.Lerp(transform.localRotation, targetPos.localRotation, Time.deltaTime * MovementSpeed);

            float distance = Vector3.Distance(transform.localPosition, targetPos.localPosition);

            if (distance < 0.01f)
            {
                transform.localPosition = targetPos.localPosition;
                transform.localRotation = targetPos.localRotation;
                IsMoving = false;
            }
        }
    }

   
}
