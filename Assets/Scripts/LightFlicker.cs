using System.Collections;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{
    public Light Light;
    public float MinIntensity = 0f;
    public float MaxIntensity = 5f;
    public float MinInterval = 0.2f;
    public float MaxInterval = 2f;

    public SwitchBoard SwitchBoard;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Flicker());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Flicker()
    {
        while (SwitchBoard.AllSwitchesCorrect() == false)
        {
            float newIntensity = randomIntensity();
            float newInterval = randomInterval();

            Light.intensity = newIntensity;

            float wait = 0.1f;
            yield return new WaitForSeconds(wait);

            Light.intensity = 0f;

            yield return new WaitForSeconds(newInterval);
        }
    }

    private float randomIntensity()
    {
        return Random.Range(MinIntensity, MaxIntensity);
    }

    private float randomInterval()
    {
        return Random.Range(MinInterval, MaxInterval);
    }
   
}
