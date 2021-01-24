    using UnityEngine;
    using UnityEngine.Video;
    
    public class VideoSpeedControl : MonoBehaviour
    {
        //The material that Video will output to
        Renderer outputRenderer;
    
        private VideoPlayer videoPlayer;
    
        //Audio
        private AudioSource audioSource;
    
        void Start()
        {
    
            outputRenderer = gameObject.AddComponent<MeshRenderer>();
    
            //Add VideoPlayer to the GameObject
            videoPlayer = gameObject.AddComponent<VideoPlayer>();
    
            //Add AudioSource
            audioSource = gameObject.AddComponent<AudioSource>();
    
            //Disable Play on Awake for both Video and Audio
            videoPlayer.playOnAwake = false;
            audioSource.playOnAwake = false;
    
            // We want to play from url
            videoPlayer.source = VideoSource.Url;
            videoPlayer.url = "http://www.quirksmode.org/html5/videos/big_buck_bunny.mp4";
    
            //Set Audio Output to AudioSource
            videoPlayer.audioOutputMode = VideoAudioOutputMode.AudioSource;
    
            //Assign the Audio from Video to AudioSource to be played
            videoPlayer.EnableAudioTrack(0, true);
            videoPlayer.SetTargetAudioSource(0, audioSource);
    
            //Set the mode of output
            videoPlayer.renderMode = VideoRenderMode.MaterialOverride;
    
            //Set the renderer to store the images to
            //outputRenderer = videoPlayer.targetMaterialRenderer;
            videoPlayer.targetMaterialProperty = "_MainTex";
    
            //Prepare Video to prevent Buffering
            videoPlayer.Prepare();
    
            //Subscribe to prepareCompleted event
            videoPlayer.prepareCompleted += OnVideoPrepared;
        }
    
        void OnVideoPrepared(VideoPlayer source)
        {
            Debug.Log("Done Preparing Video");
    
            //Play Video
            videoPlayer.Play();
    
            //Play Sound
            audioSource.Play();
    
            //Change Play Speed
            if (videoPlayer.canSetPlaybackSpeed)
            {
                videoPlayer.playbackSpeed = 1f;
            }
        }
    
        bool firsrRun = true;
        void Update()
        {
            if (firsrRun)
            {
                GameObject.Find("DisplayObject").GetComponent<MeshRenderer>().material = outputRenderer.material;
                firsrRun = false;
            }
        }
    }
