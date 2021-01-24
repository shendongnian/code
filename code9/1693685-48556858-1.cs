     static void Main(string[] args)
             {
                 webcam = new WebCam();
                 webcam.InitializeWebCam(ref image);
     
                 webcam.Start();
                 Console.ReadLine();
             }
