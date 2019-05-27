using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightNoiseFlicker : MonoBehaviour
{
    public float flickerSpeed = 1;
    public float lightMin = 1;
    public float lightMax = 2;

    private Light _light;

    void Start()
    {
        _light = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        float noise = Mathf.PerlinNoise(Time.time * flickerSpeed, 0);

        _light.intensity = Mathf.Lerp(lightMin, lightMax, noise);
    }

    public void SetSpeed(float x)
    {
        if (x >= 0)
            flickerSpeed = x;
    }
}
