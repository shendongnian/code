    private IIPCamera _camera;
    private DrawingImageProvider _imageProvider = new DrawingImageProvider();
    private MediaConnector _connector = new MediaConnector();
    private VideoViewerWF _videoViewerWF1;
 
    public Form1()
    {
        InitializeComponent();
 
        // Create video viewer UI control
        _videoViewerWF1 = new VideoViewerWF();
        _videoViewerWF1.Name = "videoViewerWF1";
        _videoViewerWF1.Size = panel1.Size;
        panel1.Controls.Add(_videoViewerWF1);
 
        // Bind the camera image to the UI control
        _videoViewerWF1.SetImageProvider(_imageProvider);
    }
 
    // Connect camera video channel to image provider and start
    private void connectBtn_Click(object sender, EventArgs e)
    {
        _camera = IPCameraFactory.GetCamera("rtsp://192.168.113.150:554/ufirststream", "root", "pass");
        _connector.Connect(_camera.VideoChannel, _imageProvider);
        _camera.Start();
        _videoViewerWF1.Start();
    }
