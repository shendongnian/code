    conn.Open();
    SqlDataAdapter da = new SqlDataAdapter("select * from Territories where TerritoryName IN (" + stringComparision + ") ", conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    conn.Close();
