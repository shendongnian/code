      public Dictionary<int, string> CheckUserLogin(UserL User)
            {
                   var dict = new Dictionary<int, string>();
                using (SqlConnection con = new SqlConnection(conexion))
                {
                    SqlCommand comObj = new SqlCommand("spLogin", con);
                    comObj.CommandType = CommandType.StoredProcedure;
                    comObj.Parameters.Add(new SqlParameter("@username", User.UserName));
                    comObj.Parameters.Add(new SqlParameter("@password", User.Password));
                    con.Open();
                   using (SqlDataReader reader = command.ExecuteReader())
                   {
                        // Call Read before accessing data.
                        while (reader.Read())
                       {
                         dict.Add((int)reader["Id"],
                           reader["Username"]==DBNull.Value ?"":
                                (string)reader["Username"]);
                       }
                   }
               }
               return dict;
           }
        
