    HttpCookie cookie = new HttpCookie("The Name I Wish"); // Create a cookie and give it a name
    cookie.Expires = DateTime.Now.AddDays(30);       // expries in one month
    cookie.Value = "Some Value";                          // set value
    HttpContext.Response.Cookies.Add(cookie); 
    HttpCookie cookie1 = new HttpCookie("The Other unique Name I Wish"); // Create a cookie and give it a name
    cookie1.Expires = DateTime.Now.AddDays(20);       // expries in 20 days
    cookie1.Value = "Some other value Value";                          // set value
    HttpContext.Response.Cookies.Add(cookie1);
