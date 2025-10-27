using UnityEngine;

public class Switch : MonoBehaviour
{
    public bool CorrectState;
    private bool currentState;
    
    public void Toggle()
    {
        currentState = !currentState;
    }

    public bool IsCorrect()
    {
        return currentState == CorrectState;
    }
}
