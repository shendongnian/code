    static void Main() 
    {
        string cs = "URI=file:test.db";
        using(SqliteConnection con = new SqliteConnection(cs))
        {
            con.Open();
            string stm = "Select * from ContryLookup";
            using (SqliteCommand cmd = new SqliteCommand(stm, con))
            {
                using (SqliteDataReader rdr = cmd.ExecuteReader())
                {
                    while (rdr.Read()) 
                    {
                        Console.WriteLine(rdr.GetInt32(0) + " " 
                            + rdr.GetString(1) + " " + rdr.GetInt32(2));
                    }         
                }
            }
            con.Close();   
         }
    }
