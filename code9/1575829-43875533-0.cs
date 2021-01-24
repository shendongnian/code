    SqlConnection con = new SqlConnection("connectionString");
    SqlCommand commnad = new SqlCommand("Select * From bruker Where Brukernavn=@username and Passord=@password", con);
    
         commnad.Parameters.AddWithValue("@username", Textbox1.Text.Trim);
         commnad.Parameters.AddWithValue("@password", Textbox2.Text.Trim);
