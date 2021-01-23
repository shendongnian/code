    public class MainActivity : Activity, View.IOnClickListener 
    { 
        protected override void OnCreate (Bundle bundle) 
        { 
            base.OnCreate (bundle);
            Window.DecorView.SetOnClickListener(this)
        }
    }
