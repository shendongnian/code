    public class CustomRequestHandler : DefaultRequestHandler
    {
        string script = "alert('hello');";
        public override IResponseFilter GetResourceResponseFilter(CefSharp.IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            if (frame.IsMain && request.ResourceType == ResourceType.MainFrame)
            {
                return new JavascriptInjectionFilter(script);
            }
            return null;
        }
    }
