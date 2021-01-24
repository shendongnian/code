        public class UserBL
            {
                string conexion = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
                public int CheckUserLogin(UserL User)
                {
                    using (SqlConnection con = new SqlConnection(conexion))
                    {
                        SqlCommand comObj = new SqlCommand("spLogin", con);
                        comObj.CommandType = CommandType.StoredProcedure;
                        comObj.Parameters.Add(new SqlParameter("@username", User.UserName));
                        comObj.Parameters.Add(new SqlParameter("@password", User.Password));
                        con.Open();
        var dr=comObj.ExecuteScalar();
     while(dr.read())
        {
        int userid=convert.toint16(dr[0]);
        string Password=dr[1].tostring();
        // now Manipulate as per as your requirment
        }
                    }
                }
            }
