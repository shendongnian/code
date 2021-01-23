    public class SplashActivity : Activity
    {
               
        protected override void OnCreate (Bundle savedInstanceState)
        {
            base.OnCreate (savedInstanceState);
            SetContentView (Resource.Layout.splash);
            Handler handler = new Handler ();
            handler.PostDelayed (gotoMainActivity, 1000);
          
        }
        public void gotoMainActivity ()
        {
            
                var intent = new Intent (this, typeof (MainActivity));
                StartActivity (intent);
                Finish ();
            
        }
    }
