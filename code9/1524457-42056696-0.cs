    using System.Collections;
    using UnityEngine;
    using UnityEngine.UI;
    
    public class TouchMovie1 : MonoBehaviour
    {
        public string url = "http://techslides.com/demos/sample-videos/small.ogv";
        public RawImage videDisplay;
    
        // Use this for initialization
        void Start()
        {
            StartCoroutine(loadAndPlay());
        }
    
        // Update is called once per frame
        void Update()
        {
    
        }
    
        IEnumerator loadAndPlay()
        {
            // Start download
            var www = new WWW(url);
    
            // Make sure the movie is ready to start before we start playing
            var movieTexture = www.movie;
    
            //Assign the Texture to the RawImage
            videDisplay.texture = movieTexture;
    
            while (!movieTexture.isReadyToPlay)
            {
                yield return null;
                Debug.Log("Loading");
            }
    
            var gt = GetComponent<GUITexture>();
    
            // Initialize gui texture to be 1:1 resolution centered on screen
            gt.texture = movieTexture;
    
            // Assign clip to audio source
            // Sync playback with audio
            var aud = GetComponent<AudioSource>();
            aud.clip = movieTexture.audioClip;
    
            // Play both movie & sound
            movieTexture.Play();
            aud.Play();
            yield return null;
        }
    }
