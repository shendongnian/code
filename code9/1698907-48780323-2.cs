    protected void Page_Load(object sender, EventArgs e)
    {
         WebUserControl webControl21 = (WebUserControl)Page.LoadControl("~/WebUserControl.ascx");
        webControl1.ID = "template1";
        WebUserControl webControl22 = (WebUserControl)Page.LoadControl("~/WebUserControl.ascx");
        webControl2.ID = "template2";
        plh1.Controls.Add(webControl1);
        plh1.Controls.Add(webControl2);
    }
    protected void btnMainFormSave_Click(object sender, EventArgs e)
    {
        ((WebUserControl2)Page.FindControl("template1")).SaveFormValues();
        ((WebUserControl2)Page.FindControl("template2")).SaveFormValues();
    }
