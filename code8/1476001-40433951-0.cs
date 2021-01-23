    using (SqlConnection con1 = new SqlConnection(str))
    
    {
     con1.Open();
     using (SqlCommand query1 = new SqlCommand("SELECT * FROM ContactBook WHERE Name=@Name", con1))
         {
           query1.Parameters.Add("Name", SqlDbType.NVarChar).Value = SearchbyName.Name;
           using (SqlDataReader dr = query1.ExecuteReader())
            {
              while(dr.Read())
              {
                Console.WriteLine(dr[0] + " " + dr[1]);
              }
           }
         } 
     }
