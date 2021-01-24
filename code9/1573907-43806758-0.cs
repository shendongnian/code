    [Service(Name = "com.ff.GeneralService")]
    public class GeneralService : Service {
        private readonly Android.Media.MediaPlayer _player;
        public static generalService;
        public GeneralService()
        {
            _player = new Android.Media.MediaPlayer(); 
             generalService=this
        }
    
        public void RaiseAlert()
        {
            // start playing .mp3 file
        }
    
        public void KillAlert(string pass)
        {
            // stop playing .mp3 file
        }
    
        public void InitCancelActivity()
        {
            this.RaiseAlert();
    
            var i = new Intent(this, typeof(CancelActivity));
            i.SetFlags(ActivityFlags.NewTask);
            this.StartActivity(i);
        }
    }
