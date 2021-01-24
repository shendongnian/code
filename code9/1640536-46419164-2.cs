    [Activity(
        Label = "CrashDialog", 
        LaunchMode = LaunchMode.SingleTask,
        Theme = "@style/alert_dialog", 
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.SmallestScreenSize | ConfigChanges.Keyboard| ConfigChanges.KeyboardHidden|ConfigChanges.Navigation),
        ]
    public class CrashDialog : Activity
    {
        private Button btnExit, btnRestart;
        public string errorMessage;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_crash);
            errorMessage = Intent.GetStringExtra("Error_Text");
            this.SetFinishOnTouchOutside(false);
            InitView();
        }
        private void InitView()
        {
            btnExit = (Button)FindViewById(Resource.Id.cash_exit);
            btnExit.Click += (sender, e) =>
            {
                Exit();
            };
            btnRestart = (Button)FindViewById(Resource.Id.cash_restart);
            btnRestart.Click += (sender, e) =>
            {
                Restart();
            };
            TextView errorText = FindViewById<TextView>(Resource.Id.content);
            errorText.Text = errorMessage;
        }
        public override void OnBackPressed()
        {
            base.OnBackPressed();
            Exit();
        }
        private void Exit()
        {
            Java.Lang.JavaSystem.Exit(0);
            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
        }
        private void Restart()
        {
            Intent intent = BaseContext.PackageManager.GetLaunchIntentForPackage(BaseContext.PackageName);
            intent.AddFlags(ActivityFlags.ClearTop | ActivityFlags.NewTask);
            StartActivity(intent);
            Exit();
        }
    }
