    var request=this.ControllerContext.HttpContext.Request;
    var response =this.ControllerContext.HttpContext.Response;
    //OR
    // var request=System.Web.HttpContext.Current.Request;
    //var response =System.Web.HttpContext.Current.Response;
    if (request.Cookies["mycookie"] == null)
     {
        HttpCookie cookie=request.Cookies.AllKeys.Contains("mycookie")?Request.Cookies["mycookie"]: new HttpCookie("mycookie");
        cookie.Value = "test";//your problem hear.
        cookie.Expires = DateTime.Now.AddDays(90);
        cookie.HttpOnly = true;  
        if (request.Cookies.AllKeys.Contains("mycookie"))
        {
          response.Cookies.SetCookie(cookie);
        }
        else
        {
          response.Cookies.Add(cookie);
        }
      }
