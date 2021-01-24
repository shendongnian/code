    using (var con = new SqlConnection(cs.DBConn))
    {
        con.Open();
        cmd = new SqlCommand("SELECT full_name from name where name like '%' + @p0 OR name LIKE @p0 + '%' order by name", con); 
        // or perhaps just "where name like '%' + @p0 + '%' order by name"
        cmd.Parameters.AddWithValue("@p0", textBox3.Text);
        using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
        {
            dataGridView1.Rows.Clear();
            while (rdr.Read() == true)
            {
                dataGridView1.Rows.Add(rdr[0]);    
            }
        }
    }
