        protected void Page_Load(object sender, EventArgs e)
        {
            HttpCookie cookie = new HttpCookie("Balance");
            cookie.Values.Add("balance", "akash".ToString());
            cookie.Expires = DateTime.Now.AddYears(1);
            Response.Cookies.Add(cookie);
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            var cookie = Request.Cookies["Balance"];
            cookie.Values["balance"] = "ggg".ToString();
            Response.Cookies.Add(cookie);
        }
