    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisibleAttribute(true)]
    public class DOMListener
    {
        public event Action DOMChanged;
        private WebBrowser Browser;
        public DOMListener(WebBrowser webbrowser)
        {
            this.Browser = webbrowser;
            this.Browser.ObjectForScripting = this;
            this.Browser.DocumentCompleted += OnDOMLoaded;
        }
        private void OnDOMLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            HtmlElement script = this.Browser.Document.CreateElement("script");
            script.InnerHtml = "function listenToDOM() { document.addEventListener('DOMSubtreeModified', function(e) { window.external.DOMUpdate() }); }";
            this.Browser.Document.GetElementsByTagName("body")[0].AppendChild(script);
            this.Browser.Document.InvokeScript("listenToDOM");
        }
        public void DOMUpdate()
        {
            this.DOMChanged.Invoke();
        }
    }
