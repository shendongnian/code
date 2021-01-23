     public int getLevel()
     {
         int value = 0;
         using(MySqlConnection con = new MySqlConnection("host=45.37.80.181;user=MYUSERNAME;password=MYPASSWORD;database=tcg;"))
         {
             con.Open();
             using(MySqlCommand cmd = con.CreateCommand())
             {
                 cmd.CommandText = "Select level from users where username = @ad";
                 cmd.Parameters.AddWithValue("@ad","admin");
                 MySqlDataReader reader = cmd.ExecuteReader();
                 while (reader.Read())
                 {
                     value += int.Parse(reader[0]);
                 }
            }
            con.Close();
         }
         return value;
    }
