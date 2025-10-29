using UnityEngine;

public class Switch : MonoBehaviour, IInteractable
{
    private new Renderer renderer;
    private Material originalMat;
    public Material correctMat;
    public bool CorrectPos;
    public bool CurrentPos;
    //public bool IsCorrect;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        originalMat = renderer.material;
    }

    public void Toggle()
    {
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
        Toggle();
    }

    void Update()
    {
        if (IsCorrect())
        {
            renderer.material = correctMat;
        }
        else
        {
            renderer.material = originalMat;
        }
    }

    
    
}
