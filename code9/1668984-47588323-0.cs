    public sealed partial class MainPage : Page
    { 
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Using Windows.Media.Capture.MediaCapture APIs 
                // to stream from webcam
                MediaCapture mediaCaptureMgr = new MediaCapture();
                await mediaCaptureMgr.InitializeAsync();
                MediaStreamType streamType = MediaStreamType.VideoPreview;
                // Query all properties of the specified stream type
                IEnumerable<StreamPropertiesHelper> allVideoProperties =
                     mediaCaptureMgr.VideoDeviceController.GetAvailableMediaStreamProperties(streamType).Select(x => new StreamPropertiesHelper(x));
                // Query the current preview settings
                StreamPropertiesHelper previewProperties = new StreamPropertiesHelper(mediaCaptureMgr.VideoDeviceController.GetMediaStreamProperties(MediaStreamType.VideoPreview));
                myCaptureElement.Height = previewProperties.Height;
                myCaptureElement.Width = previewProperties.Width;
                // Start capture preview.                
                myCaptureElement.Source = mediaCaptureMgr;
                await mediaCaptureMgr.StartPreviewAsync();
            }
            catch
            {
            }
        }
    }
    class StreamPropertiesHelper
    {
        private IMediaEncodingProperties _properties;
        public StreamPropertiesHelper(IMediaEncodingProperties properties)
        {
            if (properties == null)
            {
                throw new ArgumentNullException(nameof(properties));
            }
            // This helper class only uses VideoEncodingProperties or VideoEncodingProperties
            if (!(properties is ImageEncodingProperties) && !(properties is VideoEncodingProperties))
            {
                throw new ArgumentException("Argument is of the wrong type. Required: " + typeof(ImageEncodingProperties).Name
                    + " or " + typeof(VideoEncodingProperties).Name + ".", nameof(properties));
            }
            // Store the actual instance of the IMediaEncodingProperties for setting them later
            _properties = properties;
        }
        public uint Width
        {
            get
            {
                if (_properties is ImageEncodingProperties)
                {
                    return (_properties as ImageEncodingProperties).Width;
                }
                else if (_properties is VideoEncodingProperties)
                {
                    return (_properties as VideoEncodingProperties).Width;
                }
                return 0;
            }
        }
        public uint Height
        {
            get
            {
                if (_properties is ImageEncodingProperties)
                {
                    return (_properties as ImageEncodingProperties).Height;
                }
                else if (_properties is VideoEncodingProperties)
                {
                    return (_properties as VideoEncodingProperties).Height;
                }
                return 0;
            }
        }
        public uint FrameRate
        {
            get
            {
                if (_properties is VideoEncodingProperties)
                {
                    if ((_properties as VideoEncodingProperties).FrameRate.Denominator != 0)
                    {
                        return (_properties as VideoEncodingProperties).FrameRate.Numerator /
                            (_properties as VideoEncodingProperties).FrameRate.Denominator;
                    }
                }
                return 0;
            }
        }
        public double AspectRatio
        {
            get { return Math.Round((Height != 0) ? (Width / (double)Height) : double.NaN, 2); }
        }
        public IMediaEncodingProperties EncodingProperties
        {
            get { return _properties; }
        }
        public string GetFriendlyName(bool showFrameRate = true)
        {
            if (_properties is ImageEncodingProperties ||
                !showFrameRate)
            {
                return Width + "x" + Height + " [" + AspectRatio + "] " + _properties.Subtype;
            }
            else if (_properties is VideoEncodingProperties)
            {
                return Width + "x" + Height + " [" + AspectRatio + "] " + FrameRate + "FPS " + _properties.Subtype;
            }
            return String.Empty;
        }
    }
