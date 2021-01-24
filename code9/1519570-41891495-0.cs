    protected void grid_view_RowUpdating(object sender, GridViewUpdateEventArgs e)
    {
        GridViewRow row = (GridViewRow)grid_view.Rows[e.RowIndex];
        int number = Convert.ToInt32(((TextBox)row.Cells[3].FindControl("flatnumber")).Text);
        string type = ((DropDownList)row.Cells[4].FindControl("flattype")).Text;
        int max = Convert.ToInt32(((DropDownList)row.Cells[5].FindControl("flatvacancy")).Text);
        string flatID = ((Label)row.Cells[0].FindControl("flatid")).Text;
        DataTable dt = (DataTable)ViewState["Table"];
        int row1=e.RowIndex+(grid_view.PageIndex*grid_view.PageSize)
        dt.Rows[row1].BeginEdit();
        dt.Rows[row1]["Number"] = number;
        dt.Rows[row1]["Type"] = type;
        dt.Rows[row1]["Vacancy"] = max;
        dt.Rows[row1].EndEdit();
        dt.AcceptChanges();
        ViewState["Table"] = dt;
        grid_view.EditIndex = -1;
        grid_view.DataSource = dt;
        grid_view.DataBind();
    }
