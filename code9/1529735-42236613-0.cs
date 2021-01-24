    static void da_RowUpdating(object sender, SqlRowUpdatingEventArgs e)
    {
        foreach (var p in e.Command.Parameters.Cast<SqlParameter>())
        {
            p.Size = e.Row.Table.Columns[p.SourceColumn].MaxLength;
        }
    }
