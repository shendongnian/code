    static string ReadLine()
    {
        string line = Console.ReadLine();
        if (line.Equals("q", StringComparison.CurrentCultureIgnoreCase))
        {
            Environment.Exit(Environment.ExitCode);
        }
        //Other global stuff
        return line;
    }
    //Elsewhere
    Console.Write("Enter source path: ");
    _sourcePath = ReadLine(); //Note: No 'Console.' beforehand. This is your method!
    Console.Write("Enter destination path: ");
    _destinationPath = ReadLine();
    Console.Write("Do you want detailed information displayed during the copy process? ");
    string response = ReadLine();
    if (response?.Substring(0, 1).ToUpper() == "Y")
    {
        _detailedReport = true;
    }
