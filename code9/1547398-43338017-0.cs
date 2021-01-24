        public MainPage()
        {
            this.InitializeComponent();
            InitializeCameraAsync();
            InitSocket();
        }
        MediaCapture MyMediaCapture;
        VideoFrame videoFrame;
        VideoFrame previewFrame;
        IBuffer buffer;
        DispatcherTimer timer;
        StreamSocketListenerServer streamSocketSrv;
        StreamSocketClient streamSocketClient;
        private async void InitializeCameraAsync()
        {
            var allVideoDevices = await DeviceInformation.FindAllAsync(DeviceClass.VideoCapture);
            DeviceInformation cameraDevice = allVideoDevices.FirstOrDefault();
            var mediaInitSettings = new MediaCaptureInitializationSettings { VideoDeviceId = cameraDevice.Id };
            MyMediaCapture = new MediaCapture();
            try
            {
                await MyMediaCapture.InitializeAsync(mediaInitSettings);
            }
            catch (UnauthorizedAccessException)
            {
            }
            PreviewControl.Height = 180;
            PreviewControl.Width = 240;
            PreviewControl.Source = MyMediaCapture;
            await MyMediaCapture.StartPreviewAsync();
            videoFrame = new VideoFrame(BitmapPixelFormat.Bgra8, 240, 180, 0);
            buffer = new Windows.Storage.Streams.Buffer((uint)(240 * 180 * 8));
        }
