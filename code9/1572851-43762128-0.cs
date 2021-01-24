    using (FbConnection con = new FbConnection(connectionString))
    {
        con.Open();
        using (FbCommand cmd = new FbCommand("SELECT TEXT1, TEXT2 FROM TABLE WHERE CONDITION", con))
        {
            FbDataReader dr = cmd.ExecuteReader();
            if(dr.Read())
            {
                textBox1.Text = dr[0].ToString();
                textBox2.Text = dr[1].ToString();
            }
        }
        con.close();
    }
