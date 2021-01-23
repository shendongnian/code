    public class MockArgs
    {
        private Uri uri;
        private MockArgs(Uri uri)
        {
            this.uri = uri;
        }
        public static MockArgs Create(Uri arg)
        {
            return new MockArgs(arg);
        }
    }
    /** This is in a separate class that is able to see the above protected class*/
    public async void GetSelectedText(WebView sender, MockArgs mockArgs)
        {
            var s = await sender.InvokeScriptAsync("eval", new string[] { @"window.getSelection().toString(); " });
            Debug.WriteLine("selection retreived");
        }
    /** This is called from anywhere that needs to get the selected text from a WebView (that can see the above GetSelectedText() method. */
    public void TestCode(WebView sender){
            GetSelectedText(sender, MockArgs.Create(args.Uri));
         }
