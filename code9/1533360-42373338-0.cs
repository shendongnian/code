    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;
    
    public class Card : MonoBehaviour, IDraggable {
        
    
    
    	public delegate void OnCardDropped(Card card);
    	public delegate void OnCardRemoved(Card card);
    	public OnCardDropped onDrop;
    	public OnCardRemoved onRemove;
    
    	ComputerAI compAi;
    
    	Deck deckComponent;
        
    	//type of card can be "media", "technology", "military", "points", or "espionage". CaSe seNsiTivE
    	[SerializeField]
    	public string type;
    
    	[SerializeField]
    	public bool attack;
    
    	[SerializeField]
    	public bool counter;
    
    	private AudioClip tokenGrabClip;
    	private AudioClip tokenReleaseClip;
    
    	private AudioSource tokenGrab;
    	private AudioSource tokenRelease;
    
    	public AudioSource TokenGrab {
    		get{ return tokenGrab; }
    	}
    	public AudioSource TokenRelease {
    		get{ return tokenRelease; }
    	}
    
    
    	public virtual void Start() {
    		tokenGrab = AddAudio (tokenGrabClip, false, false, 0.5f);
    		tokenRelease = AddAudio (tokenReleaseClip, false, false, 0.5f);
    	}
    
    	public virtual void Awake () {
    		tokenGrabClip = Resources.Load ("Audio/tokenGrab") as AudioClip;
    		tokenReleaseClip = Resources.Load ("Audio/tokenRelease") as AudioClip;
    	}
    	
    	// Update is called once per frame
    	public virtual void Update () {
    		
    	}
    
    	// implemented from IDraggable
    	public virtual void OnDrop() {
    
    		if (onDrop != null) {
    			onDrop (this);
    		}
    	}
    
    	public virtual AudioSource AddAudio(AudioClip clip, bool isLoop, bool isPlayAwake, float vol) {
    		AudioSource newAudio = gameObject.AddComponent<AudioSource> () as AudioSource;
    		newAudio.clip = clip;
    		newAudio.loop = isLoop;
    		newAudio.playOnAwake = isPlayAwake;
    		newAudio.volume = vol;
    		return newAudio;
    	}
    }
