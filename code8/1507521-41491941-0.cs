    protected void Button1_Click(object sender, EventArgs e)
    {
        using (WebClient client = new WebClient())
        {
            byte[] response = client.UploadValues("https://www.paypal.com/cgi-bin/webscr", new NameValueCollection()
            {
                { "cmd", "_s-xclick" },
                { "hidden", "xxxx" }
            });
            string result = Encoding.UTF8.GetString(response);
        }
    }
