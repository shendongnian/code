    protected void Page_Load(object sender, EventArgs e)
    {
        UserControl1 userControl = Page.LoadControl(userControl1Path) as UserControl1;
        userControl.ID = "UserControl1";
        this.Controls.Clear();
        this.Controls.Add(userControl);
        if (Session["uc2_open"] != null)
        {
            UserContol2 userControl = Page.LoadControl(userControl2Path) as UserContol2;
            userControl.ID = "UserContol2";
            this.Controls.Clear();
            this.Controls.Add(userControl);
        }
    }
