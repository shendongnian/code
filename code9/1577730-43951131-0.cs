         static void video_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            // get new frame
            Bitmap bitmap = (Bitmap)eventArgs.Frame;
            bitmap.Save(@"C:\Users\Jakob\Desktop\Bildd.jpg");
            
        
        
        static void Main(string[] args)
        {
            bool finish = false ;
            FilterInfoCollection videoDevices = new FilterInfoCollection( FilterCategory.VideoInputDevice );
             VideoCaptureDevice videoSource = new VideoCaptureDevice( videoDevices[0].MonikerString );
            // set NewFrame event handler
            videoSource.NewFrame += new NewFrameEventHandler( video_NewFrame );
            // start the video source
            videoSource.Start();
            // signal to stop when you no longer need capturing
            //...
            do{
            if (File.Exists(@"c:\users\me\desktop\picture.jpg"))
            {
                finish = true;
            videoSource.SignalToStop();
            // ...
            }
            } while (finish != true);
