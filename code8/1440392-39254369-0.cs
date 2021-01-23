    [Activity(Label = "App7", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            // SetContentView (Resource.Layout.Main);
    
            Android.Support.V4.App.FragmentTransaction ft = SupportFragmentManager.BeginTransaction();
    
        }
    }
