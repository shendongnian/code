    public static void Main(string[] args)
    {
        var cn = new SqlConnection("Data Source=.; Initial Catalog=TestDB; Integrated Security=SSPI");
        var da = new SqlDataAdapter("SELECT * FROM dbo.test", cn);
        var cb = new SqlCommandBuilder(da);
        cb.ConflictOption = System.Data.ConflictOption.OverwriteChanges;
    
        var ds = new DataSet();
        da.Fill(ds);
        da.FillSchema(ds, SchemaType.Source);
                
        ds.Tables[0].Rows[0]["v"] = DateTime.UtcNow.Millisecond.ToString();
        da.RowUpdating += new SqlRowUpdatingEventHandler(da_RowUpdating);
        da.Update(ds);
    }
    static void da_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
    {
        foreach (var p in e.Command.Parameters.Cast<SqlParameter>())
        {
            p.Size = e.Row.Table.Columns[p.SourceColumn].MaxLength;
        }
    }
