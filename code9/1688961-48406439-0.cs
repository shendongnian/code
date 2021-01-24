     public HtmlAgilityPack.HtmlDocument GetPageSource(string url)
        {
            webBrowserCtrl = new WebBrowser();
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            StringReader content = null;
            webBrowserCtrl.ScriptErrorsSuppressed = true;
            webBrowserCtrl.Navigate(url);
            webBrowserCtrl.DocumentCompleted += webBrowserCtrl_DocumentCompleted;
        }
            private void webBrowserCtrl_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            waitTillLoad(webBrowserCtrl);
            IHTMLDocument3 documentAsIHtmlDocument = null;
            try
            {
                documentAsIHtmlDocument = (mshtml.IHTMLDocument3)webBrowserCtrl.Document.DomDocument;
                content = new StringReader(documentAsIHtmlDocument.documentElement.outerHTML);
                doc.Load(content);
            }
            catch
            {
                Console.Write("Exception from web Page: {0}", url);
            }
            finally
            {
                if (documentAsIHtmlDocument != null)
                {
                    Marshal.ReleaseComObject(documentAsIHtmlDocument);
                    documentAsIHtmlDocument = null;
                }
                content.Dispose();
                content.Close();
                webBrowserCtrl.Dispose();
                System.GC.Collect();
                System.GC.WaitForPendingFinalizers();
                EmptyWorkingSet(Process.GetCurrentProcess().Handle);
            }
            return doc;
        }
        private void waitTillLoad(WebBrowser webBrControl)
        {
            while (webBrControl.IsBusy)
                Application.DoEvents();
            for (int i = 0; i < 500; i++)
            {
                if (webBrControl.ReadyState != System.Windows.Forms.WebBrowserReadyState.Complete)
                {
                    Application.DoEvents();
                    Thread.Sleep(10);
                }
                else
                    break;
            }
            WebBrowserReadyState loadStatus;
            int waittime = 100000;
            //System.Threading.Thread.Sleep(1000000);
            int counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if ((counter > waittime) || (loadStatus == WebBrowserReadyState.Uninitialized) || (loadStatus == WebBrowserReadyState.Loading) || (loadStatus == WebBrowserReadyState.Interactive))
                {
                    break;
                }
                counter++;
            }
            counter = 0;
            while (true)
            {
                loadStatus = webBrControl.ReadyState;
                Application.DoEvents();
                if (loadStatus == WebBrowserReadyState.Complete && webBrControl.IsBusy != true)
                {
                    break;
                }
                counter++;
            }
        }
    }    
