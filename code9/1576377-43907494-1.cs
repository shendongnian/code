    public class MainActivity : Activity
    {
        private TextView nametv;
    
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
    
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
    
            nametv = FindViewById<TextView>(Resource.Id.showName);
    
            Button btn = FindViewById<Button>(Resource.Id.btn);
            btn.Click += (sender, e) =>
            {
                StartActivity(typeof(Activity2));
            };
        }
    
        protected override void OnResume()
        {
            base.OnResume();
            var preferences = PreferenceManager.GetDefaultSharedPreferences(this);
            //set text, if "Your name" is null, set default value "Empty"
            nametv.Text = preferences.GetString("Your Name", "Empty");
        }
    }
