    public class VideoPlayer
    {
        public event EndOfVideoEventHandler EndOfVideo;
        // Following delegate indicates that the a method accepting no parameter
        // and returning void can be attached as an handler to this event.
        public delegate void EndOfVideoEventHandler();
        public void EndVideo()
        {
            RaiseEndOfVideo();
        }
        private void RaiseEndOfVideo()
        {
            if (EndOfVideo != null)
            {
                // Following line of code executes the event handler which is 
                // attached to the event.
                EndOfVideo();
            }
        }
    }
    public class WebPage
    {
        public void VideoStopped()
        {
            Console.WriteLine("Video Stopped");
        }
    }
