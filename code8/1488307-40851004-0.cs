    private WebUserControl1 userControl;
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (loginOK == true)
        {
            buildControls();
        }
    }
    private void buildControls()
    {
        userControl = (WebUserControl1)LoadControl("~/WebUserControl1.ascx");
        PlaceHolder1.Controls.Add(userControl);
    }
