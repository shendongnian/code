    string formUrl = "https://idp.kk-abcdefg.de/idp/Authn/UserPassword";
    string formParams = string.Format("j_username=MyUserName&j_password=MyPassword");
        
    string cookieHeader;
    string pageSource;
    CookieContainer cookieContainer = new CookieContainer();
    Cookie cookie1 = new Cookie("<<cookiename>>", "<<cookievalue>>","/", "<<yourdomainname>>");
    Cookie cookie2 = new Cookie("<<cookiename>>", "<<cookievalue>>", "/", "<<yourdomainname>>");
    cookieContainer.Add(cookie1);
    cookieContainer.Add(cookie2);
    // You can keep adding all required cookies this way.
    var req = (HttpWebRequest)WebRequest.Create(formUrl);
    req.CookieContainer = cookieContainer;
    
    req.ContentType = "application/x-www-form-urlencoded";
    req.Method = "POST";
    byte[] bytes = Encoding.ASCII.GetBytes(formParams);
    req.ContentLength = bytes.Length;
    using (Stream os = req.GetRequestStream())
    {
        os.Write(bytes, 0, bytes.Length);
    }
    WebResponse resp = req.GetResponse();
    cookieHeader = resp.Headers["Set-cookie"];
    
    // You can access the cookies coming as part of response as following.
    HttpWebResponse response = resp as HttpWebResponse;
    if(response != null)
    {
        var cookiesCollections = response.Cookies;
    }
    using (StreamReader sr = new StreamReader(resp.GetResponseStream()))
    {
        pageSource = sr.ReadToEnd();
    }
