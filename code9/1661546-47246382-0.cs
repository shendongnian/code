     public void DisplayProfile()
    {
     string str_Query;
    str_Query = "UPDATE tbl_item SET no_of_available_item = no_of_available_item 
    + @int_result WHERE id = @myID";
 
        using (SqlConnection connection = new SqlConnection(Conn))
        using (SqlCommand cmd = new SqlCommand(str_Query , connection))
        {
            connection.Open();
            using (SqlDataReader reader = cmd.ExecuteReader())
            {
                // Check is the reader has any rows at all before starting to 
                    read.
                if (reader.HasRows)
                {
                    // Read advances to the next row.
                    while (reader.Read())
                    {
                      
                  int ID = 
                   reader.GetInt32(reader.GetOrdinal("no_of_available_item"));
                       
                  
                        if (!reader.IsDBNull(ID ))
                        {
                          
                       int_result = no_of_available_item - ID ;
               UppdateMethod(int_result );
                    }}}}
                
       public void UppdateMethod(int int_result )
      {
        string str_Query;
         str_Query = "UPDATE tbl_item SET no_of_available_item = 
        no_of_available_item + @int_result WHERE id = @myID";
       cmd= new MySqlCommand(str_Query, connection);
       cmd.Parameters.AddWithValue("@int_result", int_result);
       cmd.Parameters.AddWithValue("@myID", myID);
        connection.Open();
       cmd.ExecuteNonQuery();
       connection.Close();}
