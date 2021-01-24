			_myChromiumBrowser = new CefSharp.WinForms.ChromiumWebBrowser("http://somedomain.com")
			{
				RequestHandler = new MyRequestHandler()
			};
	public class MyRequestHandler : IRequestHandler
	{
		public bool GetAuthCredentials(IWebBrowser browserControl, IBrowser browser, IFrame frame, bool isProxy, string host, int port, string realm, string scheme, IAuthCallback callback)
		{
			return false;
		}
		public bool OnBeforeBrowse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, bool isRedirect)
		{
                        // You can check the Request object for the URL Here
			return false;
		}
		public CefReturnValue OnBeforeResourceLoad(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IRequestCallback callback)
		{
                        // You can also check the URL here
			callback.Dispose();
			return CefReturnValue.Continue;
		}
		public bool OnCertificateError(IWebBrowser browserControl, IBrowser browser, CefErrorCode errorCode, string requestUrl, ISslInfo sslInfo, IRequestCallback callback)
		{
			callback.Dispose();
			return false;
		}
		public bool OnOpenUrlFromTab(IWebBrowser browserControl, IBrowser browser, IFrame frame, string targetUrl, WindowOpenDisposition targetDisposition, bool userGesture)
		{
			return false;
		}
		public void OnPluginCrashed(IWebBrowser browserControl, IBrowser browser, string pluginPath)
		{
		}
		public bool OnProtocolExecution(IWebBrowser browserControl, IBrowser browser, string url)
		{
			return false;
		}
		public bool OnQuotaRequest(IWebBrowser browserControl, IBrowser browser, string originUrl, long newSize, IRequestCallback callback)
		{
			callback.Dispose();
			return false;
		}
		public void OnRenderProcessTerminated(IWebBrowser browserControl, IBrowser browser, CefTerminationStatus status)
		{
		}
		public void OnRenderViewReady(IWebBrowser browserControl, IBrowser browser)
		{
		}
		public void OnResourceLoadComplete(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, UrlRequestStatus status, long receivedContentLength)
		{		
                     // You can also check the request URL here
		}
		public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, ref string newUrl)
		{
		}
		public bool OnResourceResponse(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return false;
		}
		public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
		{
			return null;
		}
		public void OnResourceRedirect(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response, ref string newUrl)
		{
		}
		public bool OnSelectClientCertificate(IWebBrowser browserControl, IBrowser browser, bool isProxy, string host, int port, System.Security.Cryptography.X509Certificates.X509Certificate2Collection certificates, ISelectClientCertificateCallback callback)
		{
			callback.Dispose();
			return false;
		}
