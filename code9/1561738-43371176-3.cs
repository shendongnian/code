    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if(e.CommandName == "ShowDropDown")
        {
            var row = GridView1.Rows[Convert.ToInt32(e.CommandArgument)];
            //Using Cell[4] coz the Dropdownlist is in 5th column of the row.
            //You need to replace 4 with appropriate column index here.
            //Also replace "dropDownList" with the ID assigned to the dropdown list in ASPX.
            var ddl = (DropDownList)row.Cells[4].FindControl("dropDownList");
            if(ddl != null)
            {
                ddl.Visible = true;
            }
        }
    }
