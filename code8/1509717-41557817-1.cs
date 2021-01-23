    protected void Button2_Click(object sender, EventArgs e)
    {
        dil = "en-US";
        Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(dil);
        Thread.CurrentThread.CurrentUICulture = Thread.CurrentThread.CurrentCulture;
        HttpCookie hc = new HttpCookie("dil");
        hc.Expires=DateTime.Now.AddDays(30);
        hc.Value=dil;
        HttpContext.Current.Response.Cookies.Add(hc);
    }
