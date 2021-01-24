    protected void Page_Load(object sender, EventArgs e)
    {
        HttpRequest q = Request;
        NameValueCollection n = q.QueryString;
        if (n.HasKeys())
        {
            string k = n.GetKey(0);
            if (k == "one")
            {
                string v = n.Get(0);
            }
            if (k == "two")
            {
                string v = n.Get(0);
            }
        }
    }
