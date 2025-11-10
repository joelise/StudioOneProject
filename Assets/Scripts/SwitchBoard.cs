using UnityEngine;

public class SwitchBoard : MonoBehaviour
{
    public Switch[] Switches;
    public Light[] Lights;

    private void Start()
    {
        //Lights.SetActive(false);
    }
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
        foreach (Light l in Lights)
        {
            l.intensity = 3000f;
        }
        
        //Debug.Log("Unlocked");
    }
}
