    //Hint: You don't need to call Close() if you use a using-block. It does the same ;)
    //Hint2: One while is enough because Read() automatically goes to next result
    using (var rdr = cmd.ExecuteReader(CommandBehavior.CloseConnection))
    {
       while (rdr.Read())
       {
         //Here we create a new object
         var data = new Data();
         //Here we fill the object
         data.LandId = rdr.GetInt(0);
         data.Type = rdr.GetString(1);
         data.Total = rdr.GetInt(2);
         data.Studio = rdr.GetInt(3);
         data.Bedroom1 = rdr.GetInt(4);
         data.Bedroom2 = rdr.GetInt(5);
         data.BedroomAbc = rdr.GetInt(6);
         list.Add(data);
       }
    }
