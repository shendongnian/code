    using (SqlConnection con = new SqlConnection(connectionString))
        {
        using (SqlCommand cmd = new SqlCommand("INSERT INTO MyTable(Column1, Column2) VALUES (@C1, @C2)", con))
            {
            cmd.Parameters.Add(new SqlParameter("@C1", SqlDbType.VarChar));
            cmd.Parameters.Add(new SqlParameter("@C2", SqlDbType.VarChar));
            con.Open();
            foreach (DataGridViewRow row in myDataGridView.Rows)
                {
                if (!row.IsNewRow)
                    {
                    cmd.Parameters["@C1"].Value = row.Cells[0].Value;
                    cmd.Parameters["@C2"].Value = row.Cells[1].Value;
                    cmd.ExecuteNonQuery();
                    }
                }
            }
        }
