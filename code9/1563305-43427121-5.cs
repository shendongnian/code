    public class Login
    {
        string email;
        string password;
        public int userid;
        public Login(string UserEmail, string UserPassword)
        {
            email = UserEmail;
            password = UserPassword;
        }
        public string Logined()
        {
            con.Open();
            cmd = new SqlCommand("SELECT userid from UserInformation WHERE UserEmail='" + email + "'and UserPassword='" + password + "'", con);
            cmd.Parameters.AddWithValue("@UserEmail", email);
            cmd.Parameters.AddWithValue("@UserPassword", password);
            cmd.ExecuteNonQuery();
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                Categorys obj = new Categorys();
                obj.ShowDialog();
                while (dr.Read())
                {
                    userid = Convert.ToInt32(dr["userid"]);
                }
                return msg = "You Are Successfully Login!";
            }
            else
            {
                return msg = "Sorry Incorrect Password Or Email!";
            }
        }
