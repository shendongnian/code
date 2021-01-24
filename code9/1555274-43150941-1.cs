    [Activity (Label = "People", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity  
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            global::Xamarin.Forms.Forms.Init (this, bundle);
            
            // Retrieves the "AppHome"/files folder which is the root of your app sandbox on Android 
            var appDir = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            // Locates your dbPath. If it doesn't exist, the database is gonna be created 
            // when you instantiate your SQLiteConnection object for the first time.
            string dbPath = Path.Combine(appDir , "people.db3");
            LoadApplication (new People.App (dbPath, new SQLitePlatformAndroid()));
        }
    }
