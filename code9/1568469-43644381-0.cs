    string NewDirectory = (@"D:\Files\edited\");
    Directory.CreateDirectory(NewDirectory);
    string seconds = DateTime.Now.ToString("- ss");
    string NewName = "Example Txt" + "-2.2-" + seconds;
        File.Move(file, NewDirectory + NewName + ".txt");
        Console.WriteLine(NewName);
        
