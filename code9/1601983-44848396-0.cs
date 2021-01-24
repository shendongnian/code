    ... 
    try
    {
        cmd.CommandText = "SELECT * FROM storing WHERE id=1";
        
        SqlDataReader reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            var location = reader.GetString(2);
            Console.WriteLine("Location is : " + location ); );
        }
    }
    ...
