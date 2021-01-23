    HttpContext.Response.Cookies.Append("MyCookie",
       "test cookie value",
       new Microsoft.AspNetCore.Http.CookieOptions
       {
             Expires = DateTimeOffset.Now.AddDays(1).AddMinutes(-5)
       });
    //if you want to have the same expiration date as your server's
