    string[] lines = File.ReadAllLines("MyFile.txt");
    string[] splitted;
    
    foreach(string line in lines)
    {
      splitted = line.Split(';');
      ...
    }
