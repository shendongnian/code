    using (FbConnection con = new FbConnection(connectionString))
    {
        con.Open();
        using (FbCommand cmd = new FbCoimmand("UPDATE TABLE SET TEXT1 = @Text1, TEXT2 = @Text2 WHERE CONDITION))
        {
            cmd.Parameters.AddWithValue("@Text1", textBox1.Text);
            cmd.Parameters.AddWithValue("@Text2", textBox2.Text);
            cmd.ExecuteNonQuery();
        }
        con.Close();
    }
