    con.Open();
    SqlCommand cmd = con.CreateCommand();
    cmd.CommandType = CommandType.Text;
    cmd.CommandText = "select prumos from dbo.modelos";
    SqlDataReader dr = cmd.ExecuteReader();  
    
   
      if (dr.HasRows)
       {
          
             while(dr.Read())
            {
               var check = dr["prumos"].ToString()
                //if "2" then true, else false 
                textBox13.Visible = check == "2";
            }
               
       }
     else
      {
         //no row return
      }
