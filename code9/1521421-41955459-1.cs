     string cookievalue ;
     if ( Request.Cookies["cookie"] != null )
     {
        cookievalue = Request.Cookies["cookie"].ToString();
     }
     else
     {
        Response.Cookies["cookie"].Value = "cookie value";
     }
    //For removing cookie use following code
    
    if (Request.Cookies["cookie"] != null)
    {
        Response.Cookies["cookie"].Expires = DateTime.Now.AddDays(-1);   
    }
