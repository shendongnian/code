    foreach(var connstring in connstrings)
    {
        MySqlConnection dbConn = new MySqlConnection(connstring);
        try
        {
            dbConn.Open();
            MySqlScript script = new MySqlScript(dbConn);
            script.Query = @"[same script here]";
            script.Delimiter = @"//";
            script.Execute();
        }
        catch (Exception error)
        {
            Console.WriteLine(error.ToString());                    
        }
    }
