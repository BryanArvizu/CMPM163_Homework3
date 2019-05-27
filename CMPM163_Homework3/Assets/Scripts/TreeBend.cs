using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeBend : MonoBehaviour {

    public AudioPeer ap;
    public int partition = 0;
    public static float strength = 1;

	Renderer rend;
	void Start () {
		rend = GetComponent<Renderer> ();
        rend.material.shader = Shader.Find("CM163/TreeShader");
	}

	void LateUpdate () {

        if(ap != null)
        {
            if (partition > ap.numPartitions)
                partition = ap.numPartitions;
            else if (partition < 0)
                partition = 0;

            float mag = ap.aveMag[partition];

            // Set mag to _Bend in the TreeShader
            rend.material.SetFloat("_Bend", mag + (mag-1) * strength);
        }

	}

    public void SetStrength(float str)
    {
        if (str >= 0)
            strength = str;
    }
}

