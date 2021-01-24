    public class MainActivity : Activity
    {
        WebView webview;
        SwipeRefreshLayout mySwipeRefresh;
        WebClient myWebClient;
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            // Set our view from the "main" layout resource
            SetContentView (Resource.Layout.Main);
            webview = FindViewById<WebView>(Resource.Id.webview);
            webview.Settings.JavaScriptEnabled = true;
            webview.LoadUrl("http://www.google.com");
            mySwipeRefresh = FindViewById<SwipeRefreshLayout>(Resource.Id.swiperefresh);
            myWebClient = new WebClient();
            //register myOnProgressChanged here
            myWebClient.myOnProgressChanged += (int state) =>
            {
                if (state == 0)
                {
                    mySwipeRefresh.Refreshing = false;
                    
                }
                else
                {
                    mySwipeRefresh.Refreshing = true;
                }
            };
            webview.SetWebViewClient(myWebClient);
            mySwipeRefresh.Refresh += SwipeRefresh_Refresh;
        }
        private void SwipeRefresh_Refresh(object sender, System.EventArgs e)
        {
            //refresh the webview when user swipes.
            webview.LoadUrl(webview.Url);
        }
    }
