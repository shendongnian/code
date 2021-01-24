    public ActionResult Login()
    {
       HttpCookie cookie = new HttpCookie("customer", "value");
       this.Response.SetCookie( cookie );
    }
