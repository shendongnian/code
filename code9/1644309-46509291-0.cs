    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create("URL");
    webRequest.ContentType = "text/plain;charset=UTF-8";
    webRequest.Accept = "text/plain;charset=UTF-8";
    webRequest.Method = "POST";
    using (StreamWriter requestStream = new StreamWriter(webRequest.GetRequestStream())) {
        requestStream.WriteLine("Hello");
    }
    HttpWebResponse webResponse = (HttpWebResponse)webRequest.GetResponse();
    using (StreamReader responseStream = new StreamReader(webResponse.GetResponseStream())) {
        Console.WriteLine(responseStream.ReadToEnd());
    }
