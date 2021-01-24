    public class MainActivity : Activity
    {
        private int currentVolume;
        public AudioManager mAudioManager;
        private int maxVolume;
        private bool isDestory;
        Android.Media.MediaPlayer player;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            player = Android.Media.MediaPlayer.Create(this, Resource.Raw.SampleAudio);
            SetContentView (Resource.Layout.Main);
            mAudioManager = (AudioManager)GetSystemService(Context.AudioService);
            maxVolume = mAudioManager.GetStreamMaxVolume(Stream.Music);
            onVolumeChangeListener();
            player.Start();
        }
        protected override void OnDestroy()
        {
            base.OnDestroy();
            isDestory = true;
        }
        private Task voluemChangeTask;
        public void onVolumeChangeListener()
        {
            currentVolume = mAudioManager.GetStreamVolume(Stream.Music);
            voluemChangeTask = new Task(ChangeVolume);
            voluemChangeTask.Start();
        }
        public void ChangeVolume()
        {
            while (!isDestory)
            {
                int count = 0;
                try
                {
                    Thread.Sleep(20);
                }
                catch (Exception e)
                {
                }
                if (currentVolume < mAudioManager.GetStreamVolume(Stream.Music))
                {
                    System.Console.WriteLine("volunm+");
                    count++;
                    currentVolume = mAudioManager.GetStreamVolume(Stream.Music);
                    mAudioManager.SetStreamVolume(Stream.Music, currentVolume, VolumeNotificationFlags.RemoveSoundAndVibrate);
                }
                if (currentVolume > mAudioManager.GetStreamVolume(Stream.Music))
                {
                    System.Console.WriteLine("volunm-");
                    count++;
                    currentVolume = mAudioManager.GetStreamVolume(Stream.Music);
                    mAudioManager.SetStreamVolume(Stream.Music, currentVolume, VolumeNotificationFlags.RemoveSoundAndVibrate);
                }
            }
        }
    }
