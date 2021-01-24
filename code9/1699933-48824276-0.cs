    using (reader = cmd.ExecuteReader())
    {
        int i = 1;     
        while (reader.HasRows)
        {          
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
           }
           i += 1;
           reader.NextResult();
        }
    }
