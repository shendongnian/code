    CookieContainer cookies = new CookieContainer();
    try
    {
        string webAddr = "https://roosters.windesheim.nl/";
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
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine(ex.Message);
    }
    //According to my web debugger the cookie will last until the 10th of December. So need to fix a new cookie until then.
    //I noticed the url used unixtimestamps at the end of the url. So we just add the unixtimestamp at the end for each request.
    long unixTimeStamp = new DateTimeOffset(DateTime.Now).ToUnixTimeMilliseconds() - 100;
    //we are now ready to call the ajax method and get the JSON.
    try
    {
        string webAddr = "https://roosters.windesheim.nl/WebUntis/Timetable.do?request.preventCache="+unixTimeStamp.ToString();
        var httpWebRequest = (HttpWebRequest)WebRequest.Create(webAddr);
        httpWebRequest.ContentType = "application/x-www-form-urlencoded; charset=utf-8";
        httpWebRequest.Method = "POST";
        httpWebRequest.CookieContainer = cookies;
        httpWebRequest.AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate;
        httpWebRequest.Headers.Add("X-Requested-With", "XMLHttpRequest");
        using (var streamWriter = new StreamWriter(httpWebRequest.GetRequestStream()))
        {
            string json = "ajaxCommand=getWeeklyTimetable&elementType=1&elementId=13090&date=20171126&formatId=7&departmentId=0&filterId=-2";
            streamWriter.Write(json);
            streamWriter.Flush();
        }
        var httpResponse = (HttpWebResponse)httpWebRequest.GetResponse();
        using (var streamReader = new StreamReader(httpResponse.GetResponseStream()))
        {
            var responseText = streamReader.ReadToEnd();
            //THE RESULTS GETS PRINTED HERE.
            Console.Write(responseText);
        }
    }
    catch (WebException ex)
    {
        Console.WriteLine(ex.Message);
    }
