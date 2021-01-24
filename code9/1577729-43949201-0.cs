        public static  bool x = false;
        static void Main(string[] args)
        {
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice); VideoCaptureDevice videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
            videoSource.NewFrame += new NewFrameEventHandler(video_NewFrame);
            videoSource.Start();
            while (true)
            {
                if (x == true)
                {
                    videoSource.SignalToStop();
                    break;
                }
            }
        }
        static void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame.Clone();
            bitmap.Save(@"C:\Users\Skydr\Desktop\C++_Project\a.jpg");
            x = true;
        }
