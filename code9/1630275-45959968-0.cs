    class BrowserHandler
    {
        public static readonly ILogger Logger = LogManager.GetCurrentClassLogger();
    
        public BrowserHandler()
        {
            StartBrowser();
            StartBrowser();
        }
    
        private void StartBrowser()
        {
            var combination = Program.GetServer().GetNextCombination();
            Logger.Debug(combination);
            runBrowserThread(new Uri("https://www.facebook.com/search/top/?q=" + combination));
        }
    
        private void runBrowserThread(Uri url)
        {
            var th = new Thread(() => {
                var br = new WebBrowser();
                br.DocumentCompleted += browser_DocumentCompleted;
                br.Navigate(url);
                Application.Run();
            });
    
            th.SetApartmentState(ApartmentState.STA);
            th.Start();
        }
    
        void browser_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var br = sender as WebBrowser;
    
            if (br.Url == e.Url)
            {
                if (br.DocumentText.Contains("_52eh _5bcu"))
                {
                    var links = br.Document.GetElementsByTagName("div");
                    bool AnyFound=false; 
                    foreach (HtmlElement link in links)
                    {
                        if (link.GetAttribute("className") == "_52eh _5bcu")
                        {
                            Logger.Warn("Found owner for [" + e.Url.ToString().Split('=')[1] + "] " + link.InnerText);
    AnyFound= true;
                        }
                    }
    
    if(!AnyFound) {
    Logger.Warn("Finished checking [" + e.Url.ToString().Split('=')[1] + "] and found no owner.");
    }
                }
                else
                {
                    Logger.Warn("Finished checking [" + e.Url.ToString().Split('=')[1] + "] and found no owner.");
                }
    
                Application.ExitThread();
                StartBrowser();
            }
        }
    }
