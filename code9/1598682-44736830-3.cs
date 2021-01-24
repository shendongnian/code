    using Android.OS;
    using ClientApp.Portable;
    
    namespace ClientApp
    {
    	[Activity(Label = "ClientApp", MainLauncher = true, Icon = "@drawable/icon")]
    	public class MainActivity : Activity
    	{
    		protected override void OnCreate(Bundle bundle)
    		{
    			base.OnCreate(bundle);
    
    			// Set our view from the "main" layout resource
    			SetContentView(Resource.Layout.Main);
    
    			var textView = FindViewById<TextView>(Resource.Id.message);
    			var getDataButton = FindViewById<Button>(Resource.Id.getData);
    
    			getDataButton.Click += async (sender, args) =>
    			{
    				var data = await SendReceiveTest.Test("test.txt");
    				textView.Text = data;
    			};
    		}
    	}
    }
