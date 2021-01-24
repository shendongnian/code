    #!/usr/bin/env csi
    
    using System;
    using System.IO;
    using System.Runtime.CompilerServices;
    
    static string GetMyPath(
        [CallerFilePath] string path = "")
        => path;
    
    // Do not write in terms of GetMyPath() in case we are called from another script.
    static string GetMyDirectory(
        [CallerFilePath] string path = "")
        => Path.GetDirectoryName(path);
    
    Console.WriteLine($"My full path is {GetMyPath()}");
    
    Console.WriteLine($"My directory is {GetMyDirectory()}");
