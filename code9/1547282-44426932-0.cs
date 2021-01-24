    public class MyNavigationDelegate : WKNavigationDelegate 
    {
         public override void DidReceiveAuthenticationChallenge(WKWebView webView, NSUrlAuthenticationChallenge challenge, Action<nsurlsessionauthchallengedisposition, nsurlcredential=""> completionHandler) 
         {
             var credential = new NSUrlCredential("username", "password", NSUrlCredentialPersistence.ForSession);
             completionHandler(NSUrlSessionAuthChallengeDisposition.UseCredential, credential);
         }
    }
