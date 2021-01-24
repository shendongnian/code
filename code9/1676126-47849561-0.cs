    using mshtml;
    using SHDocVw;
    using System;
    using System.IO;
    
    namespace Stackoverflow.Com
    {
        internal class Scrapping
        {
            private readonly string _url;
    
            public Scrapping(string url)
            {
                _url = url;
            }
    
            public void Start(long questionId)
            {
                IWebBrowser2 ie = new InternetExplorer { Visible = true };
                ie.Navigate(Path.Combine(_url, questionId.ToString()));
                do { } while (ie.Busy || ie.ReadyState != tagREADYSTATE.READYSTATE_COMPLETE);
                string asked = GetAsked(ie);
                Console.WriteLine(asked);
                ie.Quit();
    
            }
    
            private static string GetAsked(IWebBrowser2 ie)
            {
                HTMLDocument doc = ie.Document;
                IHTMLElementCollection divs = doc.getElementsByTagName("div");
                foreach (HTMLDivElement div in divs)
                {
                    if (string.IsNullOrWhiteSpace(div.className))
                        continue;
                    if (div.className.Trim().ToLower() != "user-info")
                        continue;
                    IHTMLElementCollection spans = div.getElementsByTagName("span");
                    foreach (HTMLSpanElement span in spans)
                    {
                        if (string.IsNullOrWhiteSpace(span.className))
                            continue;
                        if (span.className == "relativetime")
                        {
                            return span.innerText;
                        }
                    }
                }
    
                return "not-found";
            }
        }
    }
