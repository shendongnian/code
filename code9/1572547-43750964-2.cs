    try
    {
       con.Open();
       using (SqlDataReader read = cmd.ExecuteReader())
       {
           if(!read.HasRows)
           {
                // Display message here that no values found
                lblError.Text ="No Data Found";
           }
           else
           {
                while (read.Read())
                {
                     // populate the text boxes here
                }
       
           }
       }
    }
