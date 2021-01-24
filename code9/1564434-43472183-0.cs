    protected void Page_Load(object sender, EventArgs e)
    {
        Button btn = new Button();
        btn.Text = "Dynamic Button";
        btn.ID = "b1"; // Server Side ID
        btn.Click += b1_click;
        logout.Controls.Add(btn);
    }
    
    public void b1_click(Object sender,EventArgs e)
    {
        Response.Redirect("~/Accounts/login.aspx");
    }
