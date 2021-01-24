    public interface IMediaEndedHandler
    {
        bool AlternateHandling(MediaPlayer player);
    }
    public class NullMediaEndedHandler : IMediaEndedHandler
    {
        public bool AlternateHandling(MediaPlayer player)
        {
            return false;
        }
    }
    public class PauseOnLastFrameHandler : IMediaEndedHandler
    {
        public bool AlternateHandling(MediaPlayer player)
        {
            player.SetMediaState(MediaPlayerStates.Pause);
            return true;
        }
    }
    public class GeneralSettings
    {
        private bool pauseOnLastFrame;
        private bool PauseOnLastFrame
        {
            get
            {
                return pauseOnLastFrame;
            }
            set
            {
                pauseOnLastFrame = value;
                MediaEndedHandler = value
                    ? new PauseOnLastFrameHandler()
                    : new NullMediaEndedHandler();
            }
        }
        public IMediaEndedHandler MediaEndedHandler = new NullMediaEndedHandler();
    }
