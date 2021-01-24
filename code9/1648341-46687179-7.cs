        public VideoPage()
        {
            this.InitializeComponent();
            if (GetDeviceFormFactorType() == DeviceFormFactorType.Phone)
            {
                VideoContent.MaxWidth = 250;
            }
        }
