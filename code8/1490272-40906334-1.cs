    string sqlCommandStatement = string.Format("SELECT {0} FROM {1}", column,table);
    using (SqlDataAdapter SQLStatement = new SqlDataAdapter(sqlCommandStatement, ConnectionString))
                {
                    DataTable dt= new DataTable();
                    SQLStatement.Fill(dt);
                    dataGridView1.DataSource = dt;
                    dataGridView1.Refresh();
                }
