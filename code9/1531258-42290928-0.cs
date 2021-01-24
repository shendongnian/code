    public class MyJSInterface:Java.Lang.Object
    {
        Activity context;
        public MyJSInterface(Activity c)
        {
            context = c;
        }
        [Export]
        [JavascriptInterface]
        public void MyCallback()
        {
            //run the SetContentView on the UI Thread
            context.RunOnUiThread(() => {
                context.SetContentView(Resource.Layout.NewLayout);
            });
        }
    }
