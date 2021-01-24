    public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
    
                var linearLayout = FindViewById<LinearLayout>(Resource.Id.lnrRootView);
    
                var textView = new TextView(this);
                textView.Text = "Added programaticlly";
                linearLayout.AddView(textView);
            }
        }
