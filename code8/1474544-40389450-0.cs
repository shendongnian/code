        int count = 0;
        string[] users = { };
        string[] coins = { };
        string[] result = { "I fucked up somewhere." };
        char[] userSeparater = { ':' };
        string path = @"FILE_PATH_HERE";
        try 
        {
            if (File.Exists(path)) 
            using (StreamReader sr = new StreamReader(path)) 
            {
                while (sr.Peek() >= 0) 
                {
                    string[] temp = sr.ReadLine().split(userSeparater);
                    users[count] = temp[0];
                    coins[count] = temp[1]
                }
            }
        } 
        catch (Exception e) 
        {
            Console.WriteLine("The process failed: {0}", e.ToString());
            return result;
        }
        if (option == "users" )
        {
            return users;
        }
        else if(option == "coins")
        {
            return coins;
        }
        else
        {
           return result;
        }
