    DirectoryInfo mainDirectory = new DirectoryInfo("E:\\TestSource");
    
    foreach(DirectoryInfo subDirectory in mainDirectory.GetDirectories())
    {
       Console.WriteLine(subDirectory.FullName);
       //go another layer deep or write a recursive method
       foreach(DirectoryInfo sub in subDirectory.GetDirectories())
       {
          Console.WriteLine(sub.FullName);
       }
    }
