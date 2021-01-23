    public void ConfirmBtn_Click(object sender, EventArgs e)
    {
         string connString1 = "FirstConnectionSTring";
         string connString2 = "SecondConnectionSTring";
       
         ExecuteNonQuery(connString1);
         ExecuteNonQuery(connString2);
    }
    
    public void ExecuteNonQuery(string connString)
    {
        using (SqlConnection connection = new SqlConnection(connString))
        {
            
             connection.Open();
             SqlCommand cmd =
                        new SqlCommand("DELETE FROM TABLE1 WHERE ID=@ID", connection);
                                  
             cmd.Parameters.AddWithValue("@ID", textbox1.Text);         
    
             cmd.ExecuteNonQuery();
             
        }
    }
