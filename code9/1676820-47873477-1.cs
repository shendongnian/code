    public string GetColumnsWithoutIdentity(string tableName, SqlConnection con)
    {
        SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM dbo.{tableName} where 1=0", con);
        DataTable dt = new DataTable();
        da.FillSchema(dt, SchemaType.Source);
        var cols = dt.Columns.Cast<DataColumn>().Where(x => !x.AutoIncrement).Select(x => x.ColumnName);
        return string.Join(",", cols);
    }
