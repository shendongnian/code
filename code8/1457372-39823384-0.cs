    class MyJavaScriptInterface : Java.Lang.Object
    {
        private Context ctx;
        public MyJavaScriptInterface(Context ctx)
        {
            this.ctx = ctx;
        }
        public MyJavaScriptInterface(IntPtr handle, JniHandleOwnership transfer)
			: base (handle, transfer)
		{
        }
        [Export("showHTML")]
        public void showHTML(string html)
        {
            Console.WriteLine(html);
        }
    }
