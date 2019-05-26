using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// create this required component....
[RequireComponent (typeof (AudioSource))]

public class AudioPeer : MonoBehaviour {

	// need to instantiate an audio source and array of samples to store the fft data.
	AudioSource _audioSource;

    public int numPartitions = 1;
    [HideInInspector] public float[] aveMag;

    // NOTE: make this a 'static' float so we can access it from any other script.
    public static float[] spectrumData = new float[512];

	// Use this for initialization
	void Start ()
    {
		_audioSource = GetComponent<AudioSource> ();
    }

	// Update is called once per frame
	void Update ()
    {
		GetSpectrumAudioSource();

        // Partition Stuffs
        aveMag = new float[numPartitions];
        float partitionIndx = 0;
        int numDisplayedBins = 512 / 2;

        for (int i = 0; i < numDisplayedBins; i++)
        {
            if (i < numDisplayedBins * (partitionIndx + 1) / numPartitions)
            {
                aveMag[(int)partitionIndx] += AudioPeer.spectrumData[i] / (512 / numPartitions);
            }
            else
            {
                partitionIndx++;
                i--;
            }
        }

        for (int i = 0; i < numPartitions; i++)
        {
            aveMag[i] = 1.0f + aveMag[i] * 100;
            if (aveMag[i] > 100)
            {
                aveMag[i] = 100;
            }
        }
    }

	void GetSpectrumAudioSource()
	{
		// this method computes the fft of the audio data, and then populates spectrumData with the spectrum data.
		_audioSource.GetSpectrumData (spectrumData, 0, FFTWindow.Hanning);
	}
}


