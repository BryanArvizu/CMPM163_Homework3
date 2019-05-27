using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyboxTint : MonoBehaviour
{
    public AudioPeer ap;
    public int partition = 0;
    public static float strength = 5;

    public Material mat;

    public Color color1;
    public Color color2;

    // Update is called once per frame
    void LateUpdate()
    {
        Color color = Color.black;
        float mag = (ap.aveMag[partition] - 1f) * strength;

        for(int i=0; i<4; i++)
        {
            color[i] = Mathf.Lerp(color1[i], color2[i], mag);
        }

        mat.SetColor("_Tint", color);
    }

    public void SetStrength(float str)
    {
        if (str >= 0)
            strength = str;
    }
}
