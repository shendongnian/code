    using (SqlConnection con = new SqlConnection(constring))
    using (SqlCommand cmd = new SqlCommand("INSERT INTO stock VALUES(@productname, @packing,@totalquantity,@rate,@expry,@dealername)", con))
    {
        cmd.Parameters.Add("@productname", SqlDbType.NVarChar);
        .... all the other parameters follow....
        con.Open();
        foreach (DataGridViewRow row in dataGridView1.Rows)
        {
            if(!row.IsNewRow)
            {
                cmd.Parameter["@productname"].Value = row.Cells["pname"].Value);
                ....
                .... set all other parameters with the row values
                ....
                cmd.ExecuteNonQuery();
            }
        }
    }
