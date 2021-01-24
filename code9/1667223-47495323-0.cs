    CookieContainer cookies = new CookieContainer();
        try
        {
            string webAddr = "https://roosters.windesheim.nl/WebUntis/?school=Windesheim#Timetable?type=1&filter=-2&departmentId=0&formatId=7&id=-1";
            var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
            httpWebRequest.ContentType = "application/json; charset=utf-8";
            httpWebRequest.Method = "POST";
            httpWebRequest.CookieContainer = cookies;
              
            httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
            httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
            var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
            using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
            {
                cookies.Add(httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri));
                //or cookies.Add(httpResponse.Cookies);
                var responseText = streamReader.ReadToEnd();
                foreach(Cookie c in httpResponse.Cookies)
                {
                    Console.WriteLine(c.ToString());
                }  
            }
        }
        catch (WebException ex)
        {
            Console.WriteLine(ex.Message);
        }
