    using UnityEngine;
    using UnityEngine.UI;
    using System.Collections;
    
    public class AudioManager : MonoBehaviour
    {
    	public Button btnOn;
    	public Button btnOff;
    
    	private AudioSource audioSource;
    
    	// Use this for initialization
    	void Start()
    	{
    		btnOn = GetComponent<Button>();
    		btnOff = GetComponent<Button>();
    
    		btnOn.onClick.AddListener(() => PlayAudio());
    		btnOff.onClick.AddListener(() => StopAudio());
    
    		audioSource = GameObject.Find("bg").GetComponent<AudioSource>();
    	}
    
    	void PlayAudio()
    	{
    		audioSource.volume = 0.5f;
    	}
    
    	void StopAudio()
    	{
    		audioSource.volume = 0f;
    	}
    }
