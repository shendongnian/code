    [Application]
    public class MainApplication : Application
    {
        public static Context AppContext;
        public MainApplication()
        {
        }
        public MainApplication(IntPtr handle, JniHandleOwnership transer) : base(handle, transer)
        {
        }
        public override void OnCreate()
        {
            base.OnCreate();
            AppCompatDelegate.CompatVectorFromResourcesEnabled = true;
        }
    }
