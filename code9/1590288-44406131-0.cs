    using (SqlConnection con = new SqlConnection(conexion))
            {
                SqlCommand comObj = new SqlCommand("spLogin", con);
                comObj.CommandType = CommandType.StoredProcedure;
                comObj.Parameters.Add(new SqlParameter("@username", User.UserName));
                comObj.Parameters.Add(new SqlParameter("@password", User.Password));
                con.Open();
                var dr = comObj.ExecuteReader();
                while(dr.Read())
                {
                  var userId = dr["Id"];
                  var username = dr["Username"];
                  // do something with your data....
                }
                con.Close();
            }
