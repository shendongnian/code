    protected void Page_Load(object sender, EventArgs e)
    {
        if (IsPostBack)
        {
            // Fetching code here
            // ...
            cmd.Parameters.AddWithValue("@username", Request.Form["username"]);
            // ...
            Label3.Text = reader.GetString("Security1");
        }
    }
