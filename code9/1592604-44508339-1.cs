    
    using System;
    using Emgu.CV;
    using Emgu.CV.CvEnum;
    static class Program
    {
        [STAThread]
        static void Main()
        {
            VideoCapture cap = new VideoCapture(0);
            if(!cap.IsOpened)
            {
                return;
            }
            cap.SetCaptureProperty(CapProp.FrameWidth, 1920);
            cap.SetCaptureProperty(CapProp.FrameHeight, 1080);
            cap.SetCaptureProperty(CapProp.Fps, 30);
            
            Mat frame = new Mat();            
            long msecCounter = 0;
            long frameNumber = 0;
            for(;;)
            {
                if(cap.Grab())
                {
                    msecCounter = (long) cap.GetCaptureProperty(CapProp.PosMsec);
                    frameNumber = (long) cap.GetCaptureProperty(CapProp.PosFrames);
                    
                    if(cap.Retrieve(frame))
                    {
                        ProcessFrame(frame, msecCounter, frameNumber);
                    }
                }
                // TODO: Determine when to quit the processing loop
            }
        }
        
        private static void ProcessFrame(Mat frame, long msecCounter, long frameNumber)
        {
            // Again, copy frame here if you're going to queue the frame or
            // do any async processing on it.
            // TODO: Your processing code goes here.
        }
    }
