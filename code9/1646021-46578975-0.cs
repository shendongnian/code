    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string Row = e.RowIndex.ToString();        
        DataRow dtrow = default(DataRow);
        var dataTable = (DataTable)ViewState["dt"];
        dtrow = dataTable .Rows[Row];
        dataTable.Rows.Remove(dtrow);
        GridView1.DataSource = dataTable;
        GridView1.DataBind();
        CalculateItemNetAmount();
    }
