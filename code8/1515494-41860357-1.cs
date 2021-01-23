    public partial class MainWindow : Window
    {
      JavascriptManager jsmanager;
      public MainWindow()
      {
        InitializeComponent();
        jsmanager = new JavascriptManager(uiWebView);
      }
    }
    public class JavascriptManager : ILoadHandler, IRenderProcessMessageHandler
    {
      ChromiumWebBrowser webbrowser;
      string injection = "window.InjectedObject = {};";
      public JavascriptManager(ChromiumWebBrowser browser)
      {
        webbrowser = browser;
        browser.LoadHandler = this;
        browser.RenderProcessMessageHandler = this;
        //  Lets just pretend this is a real url with the example html above.
        browser.Address = "https://www.example.com/timingtest.htm"
      }
      public void OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
      {
        webbrowser.GetSourceAsync().ContinueWith(response =>
        {
          if (response != null)
          {
            if (frame.IsMain)
            {
              string html = response.Result;
              if (!html.Contains(injection))
              {
                string head = "<head>";
                int injectionpoint = html.IndexOf(head);
                if (injectionpoint != -1)
                {
                  injectionpoint = injectionpoint + head.Length;
                  html = html.Substring(0, injectionpoint) + "<script>" + injection + "</script>" + html.Substring(injectionpoint);
                  webbrowser.LoadHtml(html, "https://www.example.com/timingtest.htm");
                }
              }
            }
          }
        });
      }
    }
