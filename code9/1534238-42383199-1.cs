    protected void GridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Try This
               DropDownlist ddl =((DropDownList)e.Row.FindControl("ddlUOM"));
               Label lblCargo = ((Label)e.Row.FindControl("lblNameOfCargo"));
               if(ddl.SelectedValue == "Barrel")
               {
                 lblCargo.Text = "test";
               }    
            }
        }
