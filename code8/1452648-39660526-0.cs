    public RawImage rawImage;
    WebCamTexture webCamTexture;
    
    void Start()
    {
        intCam(); //Do this once. Only once
    }
    
    void intCam()
    {
        webCamTexture = new WebCamTexture();
        rawImage.material.mainTexture = webCamTexture;
    }
    
    public void StartMyCamera()
    {
        webCamTexture.Play();
    }
    
    public void StopMyCamera()
    {
        //to stop camera need only this line
        webCamTexture.Stop();
    }
