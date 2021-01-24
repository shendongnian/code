    string c_number = Console.ReadLine();
    using (SQLConnection con = new SQLConnection(Properties.Settings.Default.connectionSQL))
    {
          SQLCommand Command = new SQLCommand("Select * from customer_info where number=@cnumber", con);
          Command.Parameters.AddWithValue("@c_number", c_number);
          SQLDataReader Reader = Command.ExecuteReader();
         // Now use the data reader
    } 
