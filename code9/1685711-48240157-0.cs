        public void DownloadFileIexplore(string filePath)
        {
	        //Click the link.
	        //Simple click can be used instead, but in my case it didn't work for all the links, so i've replaced it with click via action: 
            new Actions(Browser.Driver).MoveToElement(Element).Click(Element).Perform();
	        //Different types of element can be used to download file.
	        //If the element contains direct link, it can be extracter from 'href' attribute.
	        //If the element doesn't contains href or it's just an javascript command, link will be extracted from the browser http requests.
            //
            string downloadUrlOrLink = Element.GetAttribute("href") != null && !Element.GetAttribute("href").Contains("javascript")
                ? Element.GetAttribute("href")
                : GetRequestUrls().Last() ?? GetLinkInNewWindowIexplore();
            if (downloadUrlOrLink == null)
            {
                throw Log.Exception("Download url cannot be read from the element href attribute and from the recent http requests.");
            }
	        /// the last step is to download file using CookieWebClient
	        /// method DownloadFile is available in the System.Net.WebClient, 
	        /// but we have to create new class CookieWebClient, that will be inherited from System.Net.WebClient with one overriden method
            new CookieWebClient(GetCookies()).DownloadFile(downloadUrlOrLink, filePath);
        }
        /// <summary>
	    /// this method returns all the http requests sent from browser.
	    /// the latest requests was send when link (or button) was clicked to download file
	    /// so we will need just to get last element from list: GetRequestUrls().Last().
	    /// or, if the request for file downloading isn't the last, find the required request by part of url, in my case it was 'common/handler', e.g.:
	    /// GetRequestUrls().LastOrDefault(x => x.Contains("common/handler")) 
        /// <summary>
        public List<string> GetRequestUrls()
        {
            ReadOnlyCollection<object> requestsUrls = (ReadOnlyCollection<object>) 
                Driver.ExecuteScript("return window.performance.getEntries().map(function(x) { return x.name });");
            return requestsUrls.Select(x => (string) x).ToList();
        }
        /// <summary>
        /// In some cases after clicking the Download button new window is opened in IE.
        /// Driver.WindowHandles can return only one window instead of two.
        /// To solve this problem reset IE security settings and set Enable Protected Mode for each zone.
        /// </summary>
        private string GetLinkInNewWindowIexplore()
        {
            /// here it would be better to add waiting till new window is opened.
            /// in that case we have to calculate number of windows before click and send this number as argument to GetLinkInNewWindowIexplore()
            /// and wait till number will be increased by 1 
            var availableWindows = Driver.WindowHandles;
            if (availableWindows.Count > 1)
            {
                Driver.SwitchTo().Window(availableWindows[availableWindows.Count - 1]);
            }
            string url;
            try
            {
                url = Driver.Url;
            }
            catch (Exception)
            {
                url = Driver.ExecuteScript("return document.URL;").ToString();
            }
            Driver.SwitchTo().Window(Driver.WindowHandles[0]);
            return url;
        }
        public System.Net.CookieContainer GetCookies()
        {
            CookieContainer cookieContainer = new CookieContainer();
            foreach (OpenQA.Selenium.Cookie cookie in Driver.Manage().Cookies.AllCookies)
            {
                cookieContainer.Add(new System.Net.Cookie
                {
                    Name = cookie.Name,
                    Value = cookie.Value,
                    Domain = "domain of your site, you can find, track http requests send from your site in browser dev tools, tab Network"
                });
            }
            return cookieContainer;
        }
    public class CookieWebClient : WebClient
    {
        private readonly CookieContainer _cookieContainer;
        public CookieWebClient(CookieContainer cookieContainer)
        {
            _cookieContainer = cookieContainer;
        }
	    /// it's necessary to override method to add cookies, because file cannot be download by non-authorized user
	    /// ServerCertificateValidationCallback is set to true to avoid some possible certificate errors
        protected override WebRequest GetWebRequest(Uri address)
        {
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
            WebRequest request = base.GetWebRequest(address);
            HttpWebRequest webRequest = request as HttpWebRequest;
            if (webRequest != null)
            {
                webRequest.CookieContainer = _cookieContainer;
            }
            return request;
        }
    }
