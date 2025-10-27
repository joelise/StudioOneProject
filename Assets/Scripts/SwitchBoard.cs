using UnityEngine;

public class SwitchBoard : MonoBehaviour
{
    public Switch[] Switches;
    public GameObject Lights;
    
    void Update()
    {
        if (AllSwitchesCorrect())
        {
            Unlock();  
        }
    }

    public bool AllSwitchesCorrect()
    {
        foreach (Switch s in Switches)
        {
            if (!s.IsCorrect())
            {
                return false;
            }
        }
        return true;
    }

    private void Unlock()
    {
        Debug.Log("Unlocked");
    }
}
