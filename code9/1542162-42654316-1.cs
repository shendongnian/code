    protected void OnRowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList LCList = (e.Row.FindControl("LCList") as DropDownList);
            LCList.Items.Insert(0, new ListItem("casual Leave"));
            LCList.Items.Insert(1, new ListItem("sick Leave"));
            
            If (!blnIsLOPselected )
            {
               LCList.Items.Insert(2, new ListItem("LOP"));
            }
        }
    }
