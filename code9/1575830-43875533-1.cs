    try
    {
        SqlConnection con = new SqlConnection("connectionString");
        SqlCommand commnad = new SqlCommand("Select * From bruker Where Brukernavn=@username and Passord=@password", con);
        
        commnad.Parameters.AddWithValue("@username", Textbox1.Text.Trim);
        commnad.Parameters.AddWithValue("@password", Textbox2.Text.Trim);
        //rest of the code
    }
    catch(Exception ex)
    {
      //log exception and re-throw or send a generic exception message to UI
      throw;
    }
    finally
    {
      //close the connection
    }
