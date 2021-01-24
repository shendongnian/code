     using(SqlDataReader reader=cmd.ExecuteReader())
     {
       if(reader.Hasrows)
       {
         while(reader.Read())
         {
         //We can do validation like this
         ClassnameObj.YourLabelName=reader.IsDBNull(0)?null:reader.GetString(0);
         }
       }
     }
