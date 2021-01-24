    CookieContainer cookies = new CookieContainer();
    try
    {
        string webAddr = "https://roosters.windesheim.nl/WebUntis/";
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
        httpWebRequest.ContentType = "application/json; charset=utf-8";
        httpWebRequest.Method = "POST";
        httpWebRequest.CookieContainer = cookies;
              
        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "ajaxCommand=getWeeklyTimetable&elementType=1&elementId=13092&date=20171126&formatId=7&departmentId=0&filterId=-2";
            streamWriter.Write(json);
            streamWriter.Flush();
        }
                
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            cookies.Add(httpWebRequest.CookieContainer.GetCookies(httpWebRequest.RequestUri));
            //cookies.Add(httpResponse.Cookies);
            var responseText = streamReader.ReadToEnd();
            doc.LoadHtml(responseText);
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
        Console.WriteLine(doc.DocumentNode.InnerHtml);
        Console.ReadKey();
