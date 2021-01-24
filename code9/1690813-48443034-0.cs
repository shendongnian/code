     SqlCommand selectCommand = new SqlCommand(" Select * from New_User where  
      User_Name=@USER_ID and Password=@PASS", conn);   
      //add parametars if not added
      selectCommand.Parametars.AddWithValue("@USER_ID",value); 
      selectCommand.Parametars.AddWithValue("@PASS",value");
     
      string UserType = "";
      SqlDataReader reader = selectCommand.ExecuteReader();
        if (reader.Read())
        {
                UserType = reader["User_Type"].ToString().Trim();    
                if (UserType == "ADMIN")
                {
                    bunifuFlatButton3.Visible = true;
                }
                else if (UserType == "STOCK_CON")
                {
                    bunifuFlatButton3.Visible = false;
                }
         }
