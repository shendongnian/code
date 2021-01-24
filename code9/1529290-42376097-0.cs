    public class MyRequestHandler : IRequestHandler
    {
        bool IRequestHandler.GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
        {
            if (isProxy == true)
            {             
                    callback.Continue("Username", "Password");
                    return true;
            }
            return false;
         }
    }
