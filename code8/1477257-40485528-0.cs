    private void button1_Click(object sender, EventArgs e) 
    { 
        if (comboBox1.SelectedItem.ToString() == "Admin") 
        { 
            SqlCommand cmd = new SqlCommand("select * 
                                             from Admin 
                                             where Username = @UN and 
                                                   Password = @PW");
            var unParam = new SqlParameter("@UN", SqlDbType.VarChar);
            unParam.Value = textbox1.text;
            cmd.Parameters.Add(unParam);
            var pwParam = new SqlParameter("@PW", SqlDbType.VarChar);
            pwParam.Value = textbox2.text;
            cmd.Parameters.Add(pwParam);
            SqlDataReader dr = cmd.ExecuteReader(); 
            //check if any data has returned based on the user inputs
            if (dr.HasRows)
            {
                if (dr.Read()) 
                {  
                    Admin ad = new Admin(); ad.ShowDialog(); 
                }
            } 
        } 
    }
