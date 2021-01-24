    [assembly: Dependency(typeof(DeepLinks_Android))]
    namespace MyApp.Droid
    {
        public class DeepLinks_Android : IDeepLinks
        {
            Context CurrentContext => CrossCurrentActivity.Current.Activity;
    
            public Task OpenSettings()
            {
                var myAppSettingsIntent = new Intent(Settings.ActionApplicationDetailsSettings, Android.Net.Uri.Parse("package:" + CurrentContext.PackageName));
                myAppSettingsIntent.AddCategory(Intent.CategoryDefault);
    
                return Task.Run(() =>
                {
                    try
                    {
                        CurrentContext.StartActivity(myAppSettingsIntent);
                    }
                    catch (Exception)
                    {
                        Toast.MakeText(CurrentContext.ApplicationContext, "Unable to open Settings", ToastLength.Short);
                    }
                });
            }
        }
    }
