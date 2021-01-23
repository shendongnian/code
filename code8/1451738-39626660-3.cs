    public int getLevel()
     {
         int value = 0;
         using(MySqlConnection con = new MySqlConnection("host=45.37.80.181;user=MYUSERNAME;password=MYPASSWORD;database=tcg;"))
         {
             con.Open();
             using(MySqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = "Select level from users where username = @ad";//add Order by if you need to
                 cmd.Parameters.AddWithValue("@ad","admin");
                 value += Convert.ToInt32(com.ExecuteScalar());//this assumes you will get an integer value
                 
            }
            con.Close();
         }
         return value;
    }
