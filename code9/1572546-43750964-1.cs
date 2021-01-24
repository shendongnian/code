    bool isDataFound = false;
    try
    {
       con.Open();
       using (SqlDataReader read = cmd.ExecuteReader())
       {
           while (read.Read())
           {
                isDataFound = true;
                // populate the text boxes here
           }
       }
       if(!isDataFound)
       {
          // Display message here that no values found
          lblError.Text ="No Data Found";
       }
    }
