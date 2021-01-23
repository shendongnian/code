    CookiesForCustomPolicy cookies = AmazonCloudFrontCookieSigner.GetCookiesForCustomPolicy(
        @"http://distribution123abc.cloudfront.net/*",
        new StreamReader(@"C:\bla\privatekey.pem"),
        "KEYPAIRID",
        DateTime.Now.AddHours(1),
        DateTime.Now.AddHours(-1),
        "1.1.1.1");
    string domain = ".cloudfront.net";
    HttpWebRequest pleaseWork = (HttpWebRequest)WebRequest.Create(@"http://distribution123abc.cloudfront.net/files/test.txt");
    if (pleaseWork.CookieContainer == null)
    {
        pleaseWork.CookieContainer = new CookieContainer();
    }
    pleaseWork.CookieContainer.Add(new Cookie(cookies.Signature.Key, cookies.Signature.Value) { Domain = domain } );
    pleaseWork.CookieContainer.Add(new Cookie(cookies.KeyPairId.Key, cookies.KeyPairId.Value) { Domain = domain } );
    pleaseWork.CookieContainer.Add(new Cookie(cookies.Policy.Key, cookies.Policy.Value) { Domain = domain } );
    try
    {
        WebResponse response = pleaseWork.GetResponse();
        Console.WriteLine("Response content length: " + response.ContentLength);
    }
    catch(WebException e)
    {
        Console.WriteLine(e.Message);
    }
