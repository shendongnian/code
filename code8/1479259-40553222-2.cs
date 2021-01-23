    var invalidPath = @"C:\Temp\hjk&(*&ghj\config\";
    var validPath = @"C:\Temp\hjk&(&ghj\config\"; // No asterisk (*)
    
    var invalidPathChars = System.IO.Path.GetInvalidFileNameChars().Except(new char[] { '/', '\\', ':' });
    
    if (invalidPathChars.Count(c => invalidPath.Contains(c)) > 0)
    {
        Console.WriteLine("Invalid character found.");
    }
    else
    {
    	Console.WriteLine("Free and clear.");
    }
    
    if (invalidPathChars.Count(c => validPath.Contains(c)) > 0)
    {
        Console.WriteLine("Invalid character found.");
    }
    else
    {
    	Console.WriteLine("Free and clear.");
    }
