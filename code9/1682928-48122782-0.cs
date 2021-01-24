    var client = new CookieAwareWebClient();
    client.BaseAddress = @"https://mystat.itstep.org/en/login";
    
    // do an initial get to have cookies sends to you
    // have a server session initiated
    // and we need to find the csrf token
    var login = client.DownloadString("/");
    
    string csrf;   
    // parse the file and go looking for the csrf token
    ParseLogin(login, out csrf);
    
    var loginData = new NameValueCollection();
    loginData.Add("login", "someusername");
    loginData.Add("password", "somepassword");
    loginData.Add("city_id", "29"); // I picked this value fromn the raw html
    loginData.Add("_csrf", csrf);
    var loginResult = client.UploadValues("login.php", "POST", loginData);
    // get the string from the received bytes
    Console.WriteLine(Encoding.UTF8.GetString(loginResult));
    // your task is to make sense of this result
    Console.WriteLine("Logged in!");
