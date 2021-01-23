    string myCookieName = "abcd";
    HttpCookie aCookie = new HttpCookie(myCookieName);
    aCookie.Value = DateTime.Now.ToString();
    aCookie.Expires = DateTime.Now.AddDays(1);
    Response.Cookies.Add(aCookie);
