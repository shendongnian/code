    Protected void LinkButtonClick(Object sender,EventArgs e)
    {
         HttpCookie SetCookies = Request.Cookies["linkbutton"];
         SetCookies ["linkbutton"] = "Button was click";
         SetCookies .Expires = DateTime.Now.AddDays(1d);
         Response.Cookies.Add(SetCookies);
    }
