         static void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            Bitmap bitmap = (Bitmap)eventArgs.Frame;
            bitmap.Save(@"c:\users\me\desktop\picture.jpg");
            
        
        
        static void Main(string[] args)
        {
            bool finish = false ;
            FilterInfoCollection videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );
             VideoCaptureDevice videoSource = new VideoCaptureDevice( videoDevices[0].MonikerString );
            videoSource.NewFrame += new NewFrameEventHandler( video_NewFrame );
            videoSource.Start();
            do{
            if (File.Exists(@"c:\users\me\desktop\picture.jpg"))
            {
                finish = true;
            videoSource.SignalToStop();
           }
            } while (finish != true);
        }
