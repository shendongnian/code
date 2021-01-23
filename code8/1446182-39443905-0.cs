    DataTable table = System.Data.Sql.SqlDataSourceEnumerator.Instance.GetDataSources();
        foreach (DataRow server in table.Rows)
        {
            Console.WriteLine(server["ServerName"].ToString());
            Console.Read();
        }
