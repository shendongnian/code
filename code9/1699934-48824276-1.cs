    using (reader = cmd.ExecuteReader())
    {
        if (reader.HasRows)
        {   
           int i = 1;                    
           while (reader.Read())
           {
              switch (i)
              {
                 case 1:
                 first.Text = reader["Sales"].ToString();
                 break;
                 case 2:
                 second.Text = reader["Sales"].ToString();
                 break;
                 default:
                 third.Text = reader["Sales"].ToString();
                 break;             
              } 
              i += 1;         
           }
         }
    }
