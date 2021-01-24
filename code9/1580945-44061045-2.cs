    var request=this.ControllerContext.HttpContext.Request;
    var response =this.ControllerContext.HttpContext.Response;
    //OR
    // var request=System.Web.HttpContext.Current.Request;
    //var response =System.Web.HttpContext.Current.Response;
    if (request.Cookies["mycookie"] == null)
     {
        HttpCookie cookie= new HttpCookie("mycookie");
        cookie.Value = "test";//your problem hear.
        cookie.Expires = DateTime.Now.AddDays(90);
        cookie.HttpOnly = true;      
        response.Cookies.Add(cookie);        
      }
      else
     {
        HttpCookie cookie=Request.Cookies["mycookie"];
        cookie.Value = "test";//your problem hear.
        cookie.Expires = DateTime.Now.AddDays(90);
        cookie.HttpOnly = true;  
        //response.Cookies.SetCookie(cookie);
        response.Cookies.Set(cookie);//To update a cookie, you need only to set the cookie again using the new values.
     }
       
