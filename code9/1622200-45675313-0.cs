    [Service(Exported = false, Name = "com.AudioTour.AudioService")]
    public class AudioService : Service
    {
        private AudioServiceBinder mBinder;
        public override IBinder OnBind(Intent intent)
        {
            mBinder = new AudioServiceBinder(this);
            return mBinder;
        }
        public void StartAudio()
        {
            System.Diagnostics.Debug.WriteLine("StartAudio in AudioService");
        }
        public void StopAudio()
        {
            System.Diagnostics.Debug.WriteLine("StopAudio in AudioService");
        }
    }
