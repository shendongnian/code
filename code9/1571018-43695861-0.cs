    private volatile bool doneUploading = false;
    
    byte[] videoBytes = new byte[25000];
    public Texture2D videoDisplay;
    
    Action chachedUploader;
    
    void Start()
    {
        chachedUploader = uploadToTexture;
    }
    
    void uploadToTexture()
    {
        UnityThread.executeInUpdate(() =>
        {
            //Upload the videobytes to Texture to display
            videoDisplay.LoadImage(videoBytes);
            doneUploading = true;
        });
    }
    
    //running in another Thread
    void receiveVideoFrame()
    {
        while (true)
        {
            //Download Video Frame 
            downloadVideoFrameFromNetwork(videoBytes);
    
            //Display Video Frame (Called on main thread)
            UnityThread.executeInUpdate(chachedUploader);
    
            //Wait until video is done uploading to Texture/Displayed
            while (!doneUploading)
            {
                Thread.Sleep(1);
            }
    
            //Done uploading Texture. Now set to false for the next run
            doneUploading = false;
    
            //Repeat again
        }
    }
