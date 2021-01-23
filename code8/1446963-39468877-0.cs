    object[] items = checkedListBox1.CheckedItems.OfType<object>().ToArray();
    string InStatement="("; //prepare the in clause
    foreach (var item in items)
    {
       InStatement+=item+",";
    
    }
    InStatement=InStatement.Substring(0, InStatement.Length - 1)+")";///trim last comma and add ending parenthesis
    string connectionString = "server=127.0.0.1;uid=root;pwd=admin;database=per_update;";
    string query = "select * from tblcenters where centerName in"+InStatement;
    using (MySqlConnection conn = new MySqlConnection(connectionString))
    {
        using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
        {
          DataTable ds = new DataTable();
          adapter.Fill(ds);
          dataGridView1.DataSource = ds;
        }
    }
