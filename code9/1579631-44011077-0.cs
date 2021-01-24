    String databasePath = "C:\\Users\\Dalton.Riera\\Downloads\\Summer Program Practice 0 Solution Extr\\Summer Program Practice 0 Solution\\DataBase.txt";
    StreamWriter Writer = new StreamWriter(new FileStream(databasePath,
    FileMode.Append, FileAccess.Write));
    Writer.WriteLine("Test");
                
    Writer.Close();
    Console.ReadKey();
