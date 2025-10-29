using UnityEngine;

public class SwitchBoard : MonoBehaviour
{
    public Switch[] Switches;
    public GameObject Lights;

    private void Start()
    {
        Lights.SetActive(false);
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
        Lights.SetActive(true);
        //Debug.Log("Unlocked");
    }
}
