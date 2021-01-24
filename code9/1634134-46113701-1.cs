    string sql3 = @"select * from customer_select(:pEmail, :pPassword)";    
    NpgsqlConnection pgcon = new NpgsqlConnection(pgconnectionstring);
    pgcon.Open();
    NpgsqlCommand pgcom = new NpgsqlCommand(sql3, pgcon);
    pgcom.CommandType = CommandType.Text;
    pgcom.Parameters.AddWithValue("pEmail", "myemail@hotmail.com");
    pgcom.Parameters.AddWithValue("pPassword", "eikaylie78");
    NpgsqlDataReader pgreader = pgcom.ExecuteReader();
    
    while (pgreader.Read()) {
        string name = pgreader.GetString(1);
        string surname = pgreader.GetString(2);
    }
