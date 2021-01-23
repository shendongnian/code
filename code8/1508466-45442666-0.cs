    string timestamp = CurrentTimeMillis().ToString().Trim();
    string query = @"orders/"+poID+"/acknowledge";
    string request = v3BaseUrl + query;  //Constructed URI
    string stringToSign = consumerId     + "\n" +
                          request.Trim() + "\n" +
                          "POST"         + "\n" +
                          timestamp      + "\n";
    string signedString = signData(stringToSign);  //Your signed string
    HttpWebRequest webRequest = (HttpWebRequest)WebRequest.Create(request);
    webRequest.Accept = "application/xml";
    webRequest.ContentType = "application/xml";
    webRequest.Method = "POST";
    webRequest.Headers.Add("WM_SVC.NAME", "Walmart Marketplace");
    webRequest.Headers.Add("WM_SEC.AUTH_SIGNATURE", signedString);
    webRequest.Headers.Add("WM_CONSUMER.ID", consumerId);
    webRequest.Headers.Add("WM_SEC.TIMESTAMP", timestamp.ToString().Trim());
    webRequest.Headers.Add("WM_QOS.CORRELATION_ID", Guid.NewGuid().ToString());
    webRequest.Headers.Add("WM_CONSUMER.CHANNEL.TYPE", channelType);
    webRequest.ContentLength = 0;
    webRequest.Timeout = Timeout.Infinite;
    webRequest.KeepAlive = true;
    using (HttpWebResponse response = (HttpWebResponse)webRequest.GetResponse())
    {
        if (response.StatusCode == HttpStatusCode.OK)
        {
            success = true;
        }
    }
