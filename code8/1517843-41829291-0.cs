     bool userVisited = false;
            HttpCookie cookie = Request.Cookies["Hoarding"];
            if (cookie == null)
            {
                cookie = new HttpCookie("Hoarding");
                cookie.Values.Add("userVisitedSplash", "true");
                cookie.Expires = DateTime.Now.AddDays(1);
                cookie.HttpOnly = true;
                this.Page.Response.AppendCookie(cookie);
                Response.Redirect("/default-splash.aspx");
            }
            else
            {
                if (Boolean.TryParse(cookie.Values["userVisitedSplash"], out userVisited))
                {
                    if (!userVisited)
                    {
                        Response.Redirect("/default-splash.aspx");
                    }
                }
                else
                {
                    Response.Redirect("/default-splash.aspx");
                }
            }
