    using (SqlConnection con = new SqlConnection("Data Source=YAMADA;Initial Catalog=testtest;Integrated Security=True"))
    {
        using (SqlCommand cmd = new SqlCommand("Ph", con))
        {
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@name", SqlDbType.VarChar).Value = TextBox1.Text;
            cmd.Parameters.Add("@phonenumber", SqlDbType.Int).Value = TextBox2.Text + TextBox3.Text;
            con.Open();
            cmd.ExecuteNonQuery();
        }
    }
