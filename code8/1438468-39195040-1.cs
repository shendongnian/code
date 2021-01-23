    //.cs
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "sendMsg")
        {
            //Find row in easy way
            GridViewRow row = ((Button)e.CommandSource).NamingContainer as GridViewRow;
            Label lblErr = row.FindControl("Label2") as Label;
            TextBox txt = row.FindControl("TextBox1") as TextBox;
            if (txt.Text == "test")//put your logic instead
            {
                lblErr.Text = "OK";
            }
            else
            {
                lblErr.Text = "Must be \"test\"";
            }
            //register code (function) which will run after AJAX update
            //Note that label.id comes from here
            ScriptManager.RegisterStartupScript(this, this.GetType(), "myScript", "showMsg('" + lblErr.ClientID + "');", true);
        }
    }
    
