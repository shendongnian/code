    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    [RequireComponent (typeof(AudioSource))]
    
    public class AudioRandomPitch : MonoBehaviour
    {
    
    	public float startingPitch = 1;
    	public float minPitchRandom = 0;
    	public float maxPitchRandom = 0;
    	AudioSource audio;
    
    	public float audioScale;
    
    	void Start ()
    	{
    		startingPitch = Random.Range (minPitchRandom, maxPitchRandom);
    		audio = GetComponent<AudioSource> ();
    		audio.pitch = startingPitch;
    
    		GameObject theMultiplicator = GameObject.Find ("Multiplicador_deCuerpos");
    		multipleObjectsGrandes multiplicatorScript = theMultiplicator.GetComponent<multipleObjectsGrandes> ();
    		multiplicatorScript.escalaMax = audioScale;
    
    		//this is not working
    		audio.maxDistance = audioScale;
    
    		Debug.Log(audioScale);
    
    
    
    	}
    }
