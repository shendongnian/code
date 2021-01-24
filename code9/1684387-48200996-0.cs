    namespace ShareA
    {
        [Activity(Label = "ShareA", MainLauncher = true)]
        public class MainActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                WriteSettings(this, "123");
            }
    
            private void WriteSettings(MainActivity context, string data)
            {
                try
                {
                    using (var writer = new StreamWriter(
                  OpenFileOutput("settings.dat", Android.Content.FileCreationMode.Private)))
                        writer.Write(data);
    
                    Toast.MakeText(context, "Settings saved", ToastLength.Short).Show();
                }
                catch (Exception e)
                {
                    Android.Util.Log.Error("lv",e.Message);
                    Toast.MakeText(context, "Settings not saved", ToastLength.Short).Show();
                }
    
            }
        }
    }
