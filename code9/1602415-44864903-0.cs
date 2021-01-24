    var c = new HttpCookie("JewelleryUserCookiesUserId");
    c.Value =  Convert.ToString(userid);
    c.Expires = DateTime.Now.AddYears(1);
    
    Response.Cookies.Add(c);
