    public partial class MainWindow : Window
    {
      JavascriptManager jsmanager;
      public MainWindow()
      {
        InitializeComponent();
        jsmanager = new JavascriptManager(uiWebView);
      }
    }
    public class JavascriptManager : IRequestHandler
    {
      string injection = "window.InjectedObject = {};";
      public JavascriptManager(ChromiumWebBrowser browser)
      {
        browser.RequestHandler = this;
        //  Lets just pretend this is a real url with the example html above.
        browser.Address = "https://www.example.com/timingtest.htm"
      }
      public IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            if (frame.IsMain)
            {
                string find = "<head>";
                string replace = find + "<script>" + injection + "</script>";
                return new FindReplaceResponseFilter(find, replace);
            }
            return null;
        }
    }
