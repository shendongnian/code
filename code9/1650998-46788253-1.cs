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
                // You need to be sure about what column contains the 
                // visitor name. Here for example you take the value 
                // from the third column, not from the second one.
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
