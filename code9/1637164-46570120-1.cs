    HttpCookie _userInfoCookies = new HttpCookie("UserInfo");
       //Adding Expire Time of cookies before existing cookies time
       _userInfoCookies.Expires = DateTime.Now.AddDays(-1);
       //Adding cookies to current web response
       Response.Cookies.Add(_userInfoCookies);
