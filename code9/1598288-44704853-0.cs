    public static bool TryDownloadFile(this IWebDriver driver, string url, string fileName)
    {
        try
        {
            // create HttpWebRequest
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            // insert cookies
            request.CookieContainer = new CookieContainer();
            foreach (OpenQA.Selenium.Cookie c in driver.Manage().Cookies.AllCookies)
            {
                System.Net.Cookie cookie =
                    new System.Net.Cookie(c.Name, c.Value, c.Path, c.Domain);
                request.CookieContainer.Add(cookie);
            }
            // download file
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            using (Stream responseStream = response.GetResponseStream())
            using (FileStream fileStream = File.Create(fileName))
            {
                var buffer = new byte[4096];
                int bytesRead;
                while ((bytesRead = responseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    fileStream.Write(buffer, 0, bytesRead);
                }
            }
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
