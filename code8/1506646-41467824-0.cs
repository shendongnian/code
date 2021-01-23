     [Activity(Theme = "@style/MyTheme.Splash", NoHistory = true, MainLauncher = true)]
        public class SplashScreen : Activity
        {
            static readonly string TAG = "X:" + typeof(SplashScreen).Name;
    
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                Xamarin.Forms.Forms.Init(this, savedInstanceState);
                Log.Debug(TAG, "SplashActivity.OnCreate");
            }
    
    
            protected override void OnResume()
            {
                base.OnResume();
    
                Task tmpStartupWork = new Task(() =>
                {
                    Log.Debug(TAG, "Performing some startup work that takes a bit of time.");
                    StartUpTasks.InitializeDatabaseCreation();
                    Log.Debug(TAG, "Working in the background - important stuff.");
                });
    
                tmpStartupWork.ContinueWith(inT =>
                {
                    Log.Debug(TAG, "Work is finished - start MainActivity.");
                    StartActivity(new Intent(Application.Context, typeof(MainActivity)));
                }, TaskScheduler.FromCurrentSynchronizationContext());
    
                tmpStartupWork.Start();
            }
        }
