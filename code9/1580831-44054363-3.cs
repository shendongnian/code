    protected void ddlClassUnits_SelectedIndexChanged(object sender, EventArgs e)
    {
        // get a dummy data source with 5 columns
        DataTable dt = this.GetData(5);
        // assign it as GridView data source
        this.GridViewclass.DataSource = dt;
        // create bound columns for your GridView
        foreach (DataColumn col in dt.Columns)
        {
            BoundField field = new BoundField();
            field.DataField = col.ColumnName;
            field.HeaderText = col.ColumnName;
            this.GridViewclass.Columns.Add(field);
        }
        this.GridViewclass.DataBind();
    }
    // creates a DataTable as datasource for your GridView with as many columns as you like
    private DataTable GetData(int cols)
    {
        DataTable dt = new DataTable("Class");
        // auto-generate columns
        for (int i = 0; i < cols; i++)
        {
            dt.Columns.Add($"col{i}", typeof(string));
        }
        // create an empty row just so you see something
        var dr = dt.NewRow();
        dt.Rows.Add(dr);
        return dt;
    }
