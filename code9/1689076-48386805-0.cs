    bool isOnline()
    {
        bool success = true;
        try
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("http://google.com");
            request.Method = "GET";
            //Make sure Google don't reject you when called on mobile device (Android)
            request.changeSysTemHeader("User-Agent", "Mozilla / 5.0(Windows NT 10.0; WOW64) AppleWebKit / 537.36(KHTML, like Gecko) Chrome / 55.0.2883.87 Safari / 537.36");
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            if (response == null)
            {
                success = false;
            }
            if (response != null && response.StatusCode != HttpStatusCode.OK)
            {
                success = false;
            }
        }
        catch (Exception)
        {
            success = false;
        }
        return success;
    }
