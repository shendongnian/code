    if (!System.IO.Directory.Exists(hely))
    {
        System.Console.Error.WriteLine("Directory \"{0}\" does not exist.", hely);
        System.Environment.Exit(1);
        // or: return;
    }
