    using (StreamReader sr = File.OpenText("MyFile.txt")) 
    {
      string   line;
      string[] splitted;
    
      while ((line = sr.ReadLine()) != null) 
      {
        splitted = line.Split(';');
        ...
      }
    }
