     SqlCommand selectCommand = new SqlCommand(" Select * from New_User where  
      User_Name=@USER_ID and Password=@PASS", conn);   
      //add parametars if not added (i've added "sam" and "123" just for example, you should change this to strings that user types when login"
      selectCommand.Parametars.AddWithValue("@USER_ID","sam"); 
      selectCommand.Parametars.AddWithValue("@PASS","123");
     
      string UserType = "";
      SqlDataReader reader = selectCommand.ExecuteReader();
        if (reader.Read())
        {
                UserType = reader["User_Type"].ToString();  //you don't need Trim also
                if (UserType == "ADMIN")
                {
                    bunifuFlatButton3.Visible = true;
                }
                else if (UserType == "STOCK_CON")
                {
                    bunifuFlatButton3.Visible = false;
                }
         }
