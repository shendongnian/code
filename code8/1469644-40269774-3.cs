        [Activity (Label = "App1.Droid", MainLauncher = true, Icon = "@drawable/icon")]
        	public class MainActivity : AppCompatActivity
        	{
               
                static MainActivity()  
                {
                    AppCompatDelegate.CompatVectorFromResourcesEnabled = true;
                }
        
                protected override void OnCreate (Bundle bundle)
                {
