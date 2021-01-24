    public IEnumerable<string> ParseFiles(string dir, string extension)
    {
      var result = Directory.GetFiles(dir, extension, SearchOption.AllDirectories).ToList();
      return result;
    }
    
