    bool isExisting;
    using (var conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionString"].ToString()))
    {
        conn.Open();
        using (SqlCommand cmd = new SqlCommand("some_stored_procedure", conn))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add(new SqlParameter("input", value));
            using (var adapter = new SqlDataAdapter(cmd))
            {
                DataSet ds = new DataSet();
                adapter.Fill(ds);
                isExisting = ds.Tables
                    .OfType<DataTable>()
                    .Take(1)
                    .SelectMany(t => t.Rows.OfType<DataRow>())
                    .Any(r => r["Key"].ToString() == ValueToCompareWith);
            }
        }
    }
    if (!isExisting)
    {
    }
