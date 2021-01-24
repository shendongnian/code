    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            LoadApplication(new App());
            var window = ((Activity)Forms.Context).Window;
            window.SetSoftInputMode(SoftInput.AdjustPan);
        }
       
    }
