    using CefSharp;
    public class RequestHandler : IRequestHandler
    {
        //left all the irrelevant IRequestHandler methods out of this example code, but you'll need to implement them
        public int NrOfCalls { get; set; }
        public bool OnBeforeBrowse(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool userGesture, bool isRedirect)
        {
            NrOfCalls++;
            return false;
        }
    }
    public class Handle
    {
        private RequestHandler _requestHandler;
        private IWebBrowser _browser;
        private int previousRequestNrWhereLoadingFinished = -1;
        public Handle()
        {
            _requestHandler = new RequestHandler();
            _browser.RequestHandler = _requestHandler;
        }
        private void _browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            // Check if page has finished loading
            if (!e.IsLoading)
            {
                //sometimes this is called multiple times for one request, we will only do something if it comes from a newer request than the previous action
                if (previousRequestNrWhereLoadingFinished < _requestHandler.NrOfCalls)
                {
                    previousRequestNrWhereLoadingFinished = _requestHandler.NrOfCalls;
                    ThisMethodWillOnlyBeCalledOncePerRequest();
                }
            }
        }
    }
