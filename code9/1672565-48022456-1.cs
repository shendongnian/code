    public static string DownloadString(string url)
    {
        HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
        request.Proxy = proxy;
        using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
        {
            return new StreamReader(response.GetResponseStream()).ReadToEnd();
        }
    }
