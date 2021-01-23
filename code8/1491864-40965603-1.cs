    [Activity(Label = "App5", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            
            Class1.Fetch("test", () =>
            {
                var intent = new Intent(this, typeof(OtherActivity));
                this.RunOnUiThread(() => StartActivity(intent));
            }).ContinueWith(t =>
            {
                if (t.IsCompleted) Log.Debug("Fetch", t.Result);
            });
        }
    }
