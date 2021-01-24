    string hely = ...
    try
    {
        string[] files = Directory.GetFiles(hely);
        ProcessFiles(files);
    }
    catch (DirectoryNotFoundException exc)
    {
        Console.WriteLine(exc.Message);
    }
