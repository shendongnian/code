    
    using System;
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    static class Program
    {
        private static Mat s_frame;
        private static VideoCapture s_cap;
        private static object s_retrieveLock = new object();
        [STAThread]
        static void Main()
        {
            s_cap = new VideoCapture(0);
            if(!s_cap.IsOpened)
            {
                return;
            }
            s_frame = new Mat();
            s_cap.SetCaptureProperty(CapProp.FrameWidth, 1920);
            s_cap.SetCaptureProperty(CapProp.FrameHeight, 1080);
            s_cap.SetCaptureProperty(CapProp.Fps, 30);
            
            s_cap.ImageGrabbed += FrameIsReady;
            s_cap.Start();
            // TODO: Wait here until you're done with the capture process,
            // the same way you'd determine when to exit the for loop in the
            // above example.
            s_cap.Stop();
            s_cap.ImageGrabbed -= FrameIsReady;
        }
        private static void FrameIsReady(object sender, EventArgs e)
        {
            // This function is being called from VideoCapture's thread,
            // so if you rework this code to run with a UI, be very careful
            // about updating Controls here because that needs to be Invoke'd
            // back to the UI thread.
            // I used a lock here to be extra careful and protect against
            // re-entrancy, but this may not be necessary if Emgu's
            // VideoCapture thread blocks for completion of this event
            // handler.
            lock(s_retrieveLock)
            {
                msecCounter = (long) s_cap.GetCaptureProperty(CapProp.PosMsec);
                frameNumber = (long) s_cap.GetCaptureProperty(CapProp.PosFrames);
                    
                if(s_cap.Retrieve(s_frame))
                {
                    ProcessFrame(s_frame, msecCounter, frameNumber);
                }
            }
        }
        
        private static void ProcessFrame(Mat frame, long msecCounter, long frameNumber)
        {
            // Again, copy frame here if you're going to queue the frame or
            // do any async processing on it.
            // TODO: Your processing code goes here.
        }
    }
