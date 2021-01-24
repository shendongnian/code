    using (var db_conn1 = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source= " + source))
    {
        db_conn1.Open();
        using (var cmd = new OleDbCommand())
        {
            cmd.Connection = db_conn1;
            cmd.CommandType = CommandType.Text;
            string firstSQL = "INSERT INTO access_table(Id";
            for (int i = 0; i <= (table.Rows.Count - 1); i++)
            {
                cmd.Parameters.Clear();
                string midSQL = ") VALUES(" + (i + 1).ToString();
    
                StringBuilder colNames = new StringBuilder();
                StringBuilder valParams = new StringBuilder();
                for (int j = 1; j <= (table.Columns.Count - 1); j++)
                {
                    colNames.Append(", " + table.Columns[j].ColumnName.Trim());
                    string paramName = "@add" + j.ToString();
                    valParams.Append(", " + paramName);
                    cmd.Parameters.AddWithValue(paramName, table.Rows[i].ItemArray.GetValue(j));
                }
                cmd.CommandText = firstSQL + colNames.ToString() + midSQL + valParams.ToString() + ")";
                cmd.ExecuteNonQuery();
            }
        }
    }
