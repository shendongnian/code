    using (MySqlCommand cmd = new MySqlCommand(sql, con))
    {
        try
        {
            cmd.Parameters.Add("@visit_date", MySqlDbType.DateTime);
            cmd.Parameters.Add("@visitor_name", MySqlDbType.VarChar);
            .... // add all the other parameters here
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                cmd.Parameters["@visit_date"].Value = System.DateTime.Now;
                cmd.Parameters["@visitor_name"].Value = dataGridView1.Rows[i].Cells[2].Value;
                ... again set the value at each loop for each parameter
                cmd.ExecuteNonQuery();
            }
        }
        catch(Exception ex)
        {
            MessageBox.Show(ex.ToString());
        }
    }
