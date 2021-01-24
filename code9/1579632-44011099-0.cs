        String databasePath = "C:\\Users\\Dalton.Riera\\Downloads\\Summer Program Practice 0 Solution Extr\\Summer Program Practice 0 Solution\\DataBase.txt";
        using (StreamWriter writer = new StreamWriter(new FileStream(databasePath, 
            FileMode.Append, FileAccess.Write)))
        {
            writer.WriteLine("Test");
            Console.ReadKey();
            writer.Flush();
            //writer.Close(); this may or may not be needed.
        }
