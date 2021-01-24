    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            DropDownList ddSelRAF3 = e.Row.FindControl("selrAF3") as DropDownList;
            ddSelRAF3.SelectedValue = /*Your SQL Value Here*/
        }
    }
