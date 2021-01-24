    [Activity(MainLauncher = true, Theme = "@style/MyTheme.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Intent startup = new Intent(this, typeof(MainActivity));
            StartActivity(startup);
            Finish();
        }
    }
