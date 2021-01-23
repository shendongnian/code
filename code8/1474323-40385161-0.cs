    public class LoadVideo : MonoBehaviour 
    {
        public VideoCaptureDevice videoSource;
        public GameObject originalFeed;
        Texture2D originalFeedTexture;
    
        void Start()
        {
            init();
        }
    
        void init()
        {
            originalFeedTexture = new Texture2D(128, 128);
            
            //Get WebCam names
            WebCamDevice[] devices = WebCamTexture.devices;
            if (devices.Length <= 0)
            {
                Debug.LogError("No Web Cam Found....Exiting");
                return; //Exit
            }
            videoSource = new VideoCaptureDevice(devices[0].name);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
        }
    
        void stop()
        {
            videoSource.SignalToStop();
        }
    
        void Update () 
        {
            originalFeed.GetComponent<Renderer>().material.mainTexture = originalFeedTexture;
        }
    
        public delegate void EventPrototype(System.EventArgs args);
    
        void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Debug.Log("you here mate");
            Bitmap video = (Bitmap)eventArgs.Frame.Clone();
            MemoryStream memoryStream = new MemoryStream();
            video.Save(memoryStream, ImageFormat.Jpeg);
            byte[] bitmapRecord = memoryStream.ToArray();
    
            originalFeedTexture.LoadImage(bitmapRecord);
        }
    
        //Make sure to stop when run time ends
        void OnDisable()
        {
            stop();
        }
    }
