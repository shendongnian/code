    private static void Main()
    {
        // Create your own file name
        var fileName = "MyAppData.txt";
        // Get temp path
        var tempPath = Path.GetTempPath();
            
        // Get AppData path and add a directory for your .exe
        // To use Assembly.GetExecutingAssembly, you need to add: using System.Reflection
        var appDataFolder = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        var exeName = Path.GetFileNameWithoutExtension(Assembly.GetExecutingAssembly().CodeBase);
        var appDataForThisExe = Path.Combine(appDataFolder, exeName);
        Directory.CreateDirectory(appDataForThisExe);
        // Get the path where this .exe lives
        var exePath = Path.GetDirectoryName(
            new Uri(Assembly.GetExecutingAssembly().CodeBase).LocalPath);
        // Now you can join your file name with one of the above paths
        // to construct the full path to the file you want to write
        var tempFile = Path.Combine(tempPath, fileName);
        var appDatFile = Path.Combine(appDataForThisExe, fileName);
        var exePathFile = Path.Combine(exePath, fileName);
        Console.WriteLine($"Temp file path:\n {tempFile}\n");
        Console.WriteLine($"AppData file path:\n {appDatFile}\n");
        Console.WriteLine($"Exe location file path:\n {exePathFile}");
        Console.WriteLine("\nDone!\nPress any key to exit...");
        Console.ReadKey();
    }
