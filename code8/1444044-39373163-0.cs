    using(SqlConnection con = new SqlConnection(....))
    using(SqlCommand xp = new SqlCommand(@"Insert into Revizija Values(@Broj_rev);
                                           SELECT SCOPE_IDENTITY()", con);
    {
        con.Open();
        xp.Parameters.AddWithValue("@Broj_rev", textBox5.Text);
        int rev_id Convert.ToInt32(xp.ExecuteScalar());
    
        using(SqlCommand xp1 = new SqlCommand(@"Insert into Verzija values(@Broj,@rev_id);
                                               SELECT SCOPE_IDENTITY()", con);
        {
            xp1.Parameters.AddWithValue("@Broj", textBox4.Text);
            xp1.Parameters.AddWithValue("@rev_id", rev_id);
            int verz_id = Convert.ToInt32(xp1.ExecuteScalar());
    
            using(SqlCommand xp4 = new SqlCommand(@"Insert into Program 
                   values (@Naziv_prog, @verz_id)", con);
            {
                xp4.Parameters.AddWithValue("@Naziv_prog", textBox2.Text);
                xp4.Parameters.AddWithValue("@verz_id", verz_id);
                xp4.ExecuteNonQuery();
            }
       }
    }
