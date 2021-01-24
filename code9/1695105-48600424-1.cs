    using (SqlDataReader oReader = sqlCmd.ExecuteReader())
    {
         while (oReader.Read())
          {
              userInfo.UserName = oReader["Username"].ToString();
              userInfo.PassWord = oReader["Password"].ToString();
              userInfo.Role = oReader["Role"].ToString();
              userInfo.FirstName = oReader["First_Name"].ToString();
              userInfo.LastName = oReader["Last_Name"].ToString();
          }
    }
