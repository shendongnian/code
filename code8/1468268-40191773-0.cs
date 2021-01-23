        string path = "C:\\BSD";
        string extension = Console.ReadLine();
        int count = 0;
    
        foreach (string file in Directory.GetFiles(path, "*.*",SearchOption.AllDirectories).Where(x => x.EndsWith(extension)))
        {
           Console.WriteLine(file);
           count++;
        }
    
        if (count == 0)
          throw new Exception("The Extension you wrote does not exist!!");
