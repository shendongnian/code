    public class MyWebView : WebView {
        ...
        public override IInputConnection OnCreateInputConnection (EditorInfo outAttrs) {
            var inputConnection = base.OnCreateInputConnection (outAttrs);
            // outAttrs.ImeOptions in Xamarin only allows ImeFlags but it also should allow ImeActions
            outAttrs.ImeOptions = outAttrs.ImeOptions | (ImeFlags)ImeAction.Next;
            return inputConnection;
        }
    }
