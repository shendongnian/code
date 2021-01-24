    public class TestSQLConnection
    {
          static string sqlConn = ConfigurationManager.ConnectionStrings["TestDB"].ConnectionString;
        SqlConnection con = new SqlConnection(sqlConn);
        
        public  void TestConnection()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM [Users] WHERE email=@useremail and password=@password", con);
            cmd.Parameters.Add("@useremail", SqlDbType.VarChar).Value = "David";
            cmd.Parameters.Add("@password", SqlDbType.VarChar).Value = "Fawzy";
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            con.Close();
            if (dt.Rows.Count > 0)
            {
                Console.WriteLine("Exist");
            }
            else
            {
                Console.WriteLine("Not Exist");
            }
        }
    }
