    [Activity(Label = "GoodleAuthInterceptor")]
    [IntentFilter(actions: new[] { Intent.ActionView }, Categories = new[] { Intent.CategoryDefault, Intent.CategoryBrowsable },
      DataSchemes = new[] { "com.mynamespace.myapp" }, DataPaths = new[] { "/oauth2redirect" })]
    public class GoodleAuthInterceptor : Activity
    {
      protected override void OnCreate(Bundle savedInstanceState)
      {
         base.OnCreate(savedInstanceState);
         Android.Net.Uri uri_android = Intent.Data;
         Uri uri_netfx = new Uri(uri_android.ToString());
         MainActivity.auth?.OnPageLoading(uri_netfx);
         Finish();
      }
    }
