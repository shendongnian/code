    string fileName = @"D:\Programming\Projects\Launch pad\itnol\KeySound";
    
    ...
    
    Dictionary<string, string> dict = new Dictionary<string, string>();
    
    // Do not forget to wrap IDisposable into using
    using (System.IO.StreamReader reader = new System.IO.StreamReader(fileName)) {
      while (true) {
        string line = reader.ReadLine();
     
        if (null == line)
          break;
        else if (line.Length >= 11) 
          dict.Add(line.Substring(0, 6), line.Substring(6));
      }
    }
