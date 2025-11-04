using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    private new Renderer renderer;
    private Material originalMat;
    public Material correctMat;
    public bool CorrectPos;
    public bool CurrentPos;
    public Transform StartPos;
    public Transform EndPos;
    public float MovementSpeed;

    public bool IsOpen = false;
    public bool IsMoving = false;

    private void Awake()
    {
        Transform originalPos;

        if (CurrentPos)
        {
            originalPos = EndPos;
            IsOpen = true;
        }
        else
        {
            originalPos = StartPos;
            IsOpen = false;
        }

        transform.localPosition = originalPos.localPosition;
        transform.localRotation = originalPos.localRotation;
    }
    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMat = renderer.material;

        
    }

    public void Toggle()
    {
       

        if (IsOpen == false)
        {
            IsOpen = true;
        }
        else
        {
            IsOpen = false;
        }

        CurrentPos = !CurrentPos;

        if (CurrentPos == CorrectPos)
        {

            IsCorrect();
            Debug.Log("Correct");
        }
        else
        {
           
            renderer.material = originalMat;
            Debug.Log("Incorrect");
        }

    }

    public bool IsCorrect()
    {
        //renderer.material = correctMat;
        return CurrentPos == CorrectPos;
    }

    void IInteractable.Interact()
    {
        IsMoving = true;
        Toggle();
       
    }

    void Update()
    {
        Move();

        if (IsCorrect())
        {
            renderer.material = correctMat;
        }
        else
        {
            renderer.material = originalMat;
        }
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
