    int points = 0;
    try 
    {
        points = getUserPoints("yourname");
    } 
    catch  (Exception e)
    {
        Console.WriteLine(e.Message);
    }
