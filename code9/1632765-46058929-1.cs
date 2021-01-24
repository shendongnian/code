        private static void ICloud()
        {
            var cc = new CookieContainer();
            var first = (HttpWebRequest)WebRequest.Create("https://idmsa.apple.com/appleauth/auth/signin?widgetKey=83545bf919730e51dbfba24e7e8a78d2&locale=de_DE&font=sf");
            first.Method = "GET";
            first.CookieContainer = cc;
            var response1 = (HttpWebResponse)first.GetResponse();
            using (var streamReader = new StreamReader(response1.GetResponseStream()))
            {
                var result = streamReader.ReadToEnd();
            }
            var second = (HttpWebRequest)WebRequest.Create("https://idmsa.apple.com/appleauth/auth/signin");
            second.ContentType = "application/json";
            second.Method = "POST";
            second.Accept = "application/json";
            second.CachePolicy = new RequestCachePolicy(RequestCacheLevel.NoCacheNoStore);
            second.Referrer = "https://idmsa.apple.com/appleauth/auth/signin?widgetKey=83545bf919730e51dbfba24e7e8a78d2&locale=de_DE&font=sf";
            second.Headers.Add("X-Requested-With", "XMLHttpRequest");
            second.Headers.Add("X-Apple-Widget-Key", "83545bf919730e51dbfba24e7e8a78d2");
            using (var streamWriter = new StreamWriter(second.GetRequestStream()))
            {
                string json = "{\"accountName\":\"test@icloud.com\",\"password\":\"test\",\"rememberMe\":false,\"trustTokens\":[]}";
                streamWriter.Write(json);
                streamWriter.Flush();
                streamWriter.Close();
            }
            try
            {
                var response2 = (HttpWebResponse)second.GetResponse();
                using (var streamReader = new StreamReader(response2.GetResponseStream()))
                {
                    var result = streamReader.ReadToEnd();
                }
            }
            catch(WebException we)
            {
                using (var r = new StreamReader(we.Response.GetResponseStream()))
                {
                    var result2 = r.ReadToEnd();
                }
            }
        }
