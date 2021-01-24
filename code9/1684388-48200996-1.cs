    namespace ShareB
    {
        [Activity(Label = "ShareB", MainLauncher = true)]
        public class MainActivity : Activity
        {
            TextView textView;
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
    
                // Set our view from the "main" layout resource
                SetContentView(Resource.Layout.Main);
                textView = this.FindViewById<TextView>(Resource.Id.textView1);
    
                try
                {
                    //get A's context
                    Context ctx = this.CreatePackageContext(
                            "ShareA.ShareA", Android.Content.PackageContextFlags.IgnoreSecurity);
                    //Read data
                    string msg = ReadSettings(ctx);
                    textView.Text= msg;
                    Toast.MakeText(this, "DealFile2 Settings read" + msg, ToastLength.Short).Show();
                    //Or you can change the data from B
                    WriteSettings(ctx, "deal file2 write");
                }
                catch (PackageManager.NameNotFoundException e)
                {
                    // TODO Auto-generated catch block
                    Android.Util.Log.Error("lv", e.Message);
                }
            }
    
            private string ReadSettings(Context context)
            {
                try
                {   // context is from A
                    using (var reader = new StreamReader(context.OpenFileInput("settings.dat")))
                    {
                        return reader.ReadToEnd();
                    }
                }
                catch
                {
                    return "";
                }
            }
    
            private void WriteSettings(Context context, string data)
            {
                try
                {   // context is from A
                    using (var writer = new StreamWriter(
                  context.OpenFileOutput("settings.dat", Android.Content.FileCreationMode.Private)))
                        writer.Write(data);
    
                    Toast.MakeText(context, "Settings saved", ToastLength.Short).Show();
                }
                catch (Exception e)
                {
                    Android.Util.Log.Error("lv", e.Message);
                    Toast.MakeText(context, "Settings not saved", ToastLength.Short).Show();
                }
            }
        }
    }
