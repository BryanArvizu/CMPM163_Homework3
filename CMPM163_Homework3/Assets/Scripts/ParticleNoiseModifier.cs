using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleNoiseModifier : MonoBehaviour
{
    private ParticleSystem ps;

    void Start()
    {
        ps = GetComponent<ParticleSystem>();
    }

    public void SetNoiseFrequency(float x)
    {
        var noise = ps.noise;
        noise.frequency = x;
    }
}
