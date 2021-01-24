    using UnityEngine;
    using System.Collections;
    
    public class ExampleClass : MonoBehaviour {
        public string url;
        public AudioSource source;
        void Start() {
            WWW www = new WWW(url);
            source = GetComponent<AudioSource>();
            source.clip = www.audioClip;
        }
        void Update() {
            if (!source.isPlaying && source.clip.isReadyToPlay)
                source.Play();
            
        }
    }
