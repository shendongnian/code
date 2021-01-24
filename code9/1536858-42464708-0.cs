        SqlConnection con = new SqlConnection(......);
        SqlCommand cmd = new SqlCommand("select * from v_employees", con );
        con.Open();
        DataTable table = new DataTable();
        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
        adapter.Fill(table);
        dr.Close();
        con.Close();
        dataGridView1.DataSource = table;
