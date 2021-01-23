    protected void Submit(object sender, EventArgs e)
    {
        string message = "";
        foreach (ListItem item in lstFruits.Items)
        {
            if (item.Selected)
            {
                message += item.Text + " " + item.Value + "\\n";
            }
        }
        ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", "alert('" + message + "');", true);
    }
