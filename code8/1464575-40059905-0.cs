    [Activity(Label = "YourName", , Theme = "@style/MyTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
            public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
            {
                protected override void OnCreate(Bundle bundle)
                {
                    base.OnCreate(bundle);
        
                    global::Xamarin.Forms.Forms.Init(this, bundle);
        
                    FAB.Droid.FloatingActionButtonRenderer.InitControl();
        
                    LoadApplication(new App());
                }
            }
