    protected void Button1_Click(object sender, EventArgs e)
    {
        WebUserControl1 control = lvVulnerabilityExternalIP.Items[2].FindControl("vulnerabilityExtIP") as WebUserControl1;
        control.myGridView.DataSource = mySource;
        control.myGridView.DataBind();
    }
