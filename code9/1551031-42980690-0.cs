    private List<string> GetNumbers(string input)
    {
      string x = input.Replace("[", string.Empty).Replace("]",string.Empty); 
      return x.Split(',').ToList();
    }
