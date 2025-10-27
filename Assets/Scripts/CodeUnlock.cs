using UnityEngine;
using UnityEngine.Events;

public class CodeUnlock : MonoBehaviour
{
    [Header("Code Settings")]
    public string CorrectCode;
    private bool unlocked = false;

    [Header("Code Events")]
    public UnityEvent OnCorrectCode;
    public UnityEvent OnIncorrectCode;

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
            OnCorrectCode.Invoke();
        }

        else
        {
            Debug.Log("Incorrect");
            OnIncorrectCode.Invoke();
        }
    }
}
