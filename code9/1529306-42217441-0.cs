    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e){
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            TextBox mytxt = e.Row.FindControl("txtDate") as TextBox;
            mytxt.Attributes.Add("readonly", "readonly");
        }
    }
