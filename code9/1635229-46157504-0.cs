    string comparisionString = "";
    for (int i = 0; i < listBox1.Items.Count; i++) {
        string comparisionString = listBox1.Items[i].ToString() + ",";
    }
    conn.Open();
    SqlDataAdapter da = new SqlDataAdapter("select * from Territories where TerritoryName IN ('" + comparisionString + "') ", conn);
    DataTable dt = new DataTable();
    da.Fill(dt);
    dataGridView1.DataSource = dt;
    conn.Close();
