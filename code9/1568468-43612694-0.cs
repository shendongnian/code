    string NewDirectory = (@"D:\Files\edited\");
    Directory.CreateDirectory(NewDirectory);
    string seconds = DateTime.Now.ToString("-ss");
    string NewName = "Example Txt" + "-2.2-.txt";
    string FullPath = Path.Combine(NewDirectory, NewName);
    
    if (File.Exists(FullPath))
    {
      NewName = NewName + _SomeClassInteger + ".txt"
      File.Move(file, Path.Combine(NewDirectory, NewName));
      Console.WriteLine(NewName + seconds);
    }
    else
      File.Move(file, FullPath);
    
    Console.WriteLine(NewName);
