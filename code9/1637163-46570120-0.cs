        //Creting a Cookie Object
     HttpCookie _userInfoCookies = new HttpCookie("UserInfo");
     
    //Setting values inside it
     _userInfoCookies["UserName"] = "Abhijit";
     _userInfoCookies["UserColor"] = "Red";
     _userInfoCookies["Expire"] = "5 Days";
      
     //Adding Expire Time of cookies
      _userInfoCookies.Expires = DateTime.Now.AddDays(5);
      
     //Adding cookies to current web response
     Response.Cookies.Add(_userInfoCookies);
