    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    //Find the TextBox control.
                    TextBox txtName = (e.Row.FindControl("txtName") as TextBox);
                    txtName.Enabled = false;
    
                    //or
                    TextBox txtName1 = (TextBox)e.Row.FindControl("txtName");
                    txtName1.Enabled = false;
                }
            }
