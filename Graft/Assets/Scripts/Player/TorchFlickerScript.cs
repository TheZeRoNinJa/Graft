using UnityEngine;

public class TorchFlickerScript : MonoBehaviour
{
    public Light lightsource;

    private float maxIntensity;

    private float minIntensity;

    private float currentIntensity;

    private int upOrDown;

    private float flickerAmount = 0.002f;

    public int refillCharges = 1;

    private void Start()
    {
        maxIntensity = 3f;
        minIntensity = 2.5f;
        currentIntensity = Random.Range(minIntensity, maxIntensity);
    }

    private void Update()
    {
        upOrDown = Random.Range(1, 3);
        if (upOrDown == 1 && lightsource.intensity > minIntensity)
        {
            lightsource.intensity -= flickerAmount;
        }
        if (upOrDown == 2 && lightsource.intensity < maxIntensity)
        {
            lightsource.intensity += flickerAmount;
        }
    }
}
