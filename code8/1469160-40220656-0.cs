    bool userVisited = false;
    HttpCookie cookie = Request.Cookies["MyCookie"];
    if (cookie == null)
    {
        cookie = new HttpCookie("MyCookie");
        cookie.Values.Add("userVisitedSplash", true);
        cookie.Expires = DateTime.Now.AddDays(30); //<-- Sets the expiration date
        cookie.HttpOnly = true;
        this.Page.Response.AppendCookie(cookie);
    } else{
         userVisited = cookie.Values["userVisitedSplash"]
    }
    if(userVisited){
        Response.Redirect("~/Default.aspx");
    } else{
        Response.Redirect("/homepage-hoardings/limited-offer.aspx");
    }
