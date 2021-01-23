    string insertCmd = "INSERT INTO Picture (Album) VALUES (@Album)";
            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString))
            {
                conn.Open();
                SqlCommand myCommand = new SqlCommand(insertCmd, conn);
                // Create parameters for the SqlCommand object
                // initialize with input-form field values
                myCommand.Parameters.AddWithValue("@Album", txtAlbum.Text);
            
                myCommand.ExecuteNonQuery();
    
                
            }
