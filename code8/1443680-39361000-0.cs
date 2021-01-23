    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Checking whether the Row is Data Row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Finding the Dropdown control.
            Control ctrl = e.Row.FindControl("EqpCatDDL");
            if (ctrl != null)
            {
                DropDownList dd = ctrl as DropDownList;
                List lst = new List();
                dd.DataSource = lst;
                dd.DataBind();
            }
        }
    }
