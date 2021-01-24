    browser.RenderProcessMessageHandler = new RenderProcessMessageHandler();
    
    public class RenderProcessMessageHandler : IRenderProcessMessageHandler
    {
      // Wait for the underlying `Javascript Context` to be created, this is only called for the main frame.
      // If the page has no javascript, no context will be created.
      void IRenderProcessMessageHandler.OnContextCreated(IWebBrowser browserControl, IBrowser browser, IFrame frame)
      {
        const string script = "document.addEventListener('DOMContentLoaded', function(){ alert('DomLoaded'); });";
    
        frame.ExecuteJavaScriptAsync(script);
      }
    }
    
    //Wait for the page to finish loading (all resources will have been loaded, rendering is likely still happening)
    browser.LoadingStateChanged += (sender, args) =>
    {
      //Wait for the Page to finish loading
      if (args.IsLoading == false)
      {
        browser.ExecuteJavaScriptAsync("alert('All Resources Have Loaded');");
      }
    }
    
    //Wait for the MainFrame to finish loading
    browser.FrameLoadEnd += (sender, args) =>
    {
      //Wait for the MainFrame to finish loading
      if(args.Frame.IsMain)
      {
        args.Frame.ExecuteJavaScriptAsync("alert('MainFrame finished loading');");
      }
    };
