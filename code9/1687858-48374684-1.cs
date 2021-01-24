    [Activity(MainLauncher = true, LaunchMode = Android.Content.PM.LaunchMode.SingleTop, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.main);
            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            if (toolbar != null)
            {
                SetSupportActionBar(toolbar);
                SupportActionBar.Title = "Demo App";
            }
        }
    }
