    public int Parse(string x)
    {
      x = Regex.Replace(x, "[^0-9.]", "");
      int result = 0;
      int.TryParse(x , out result);
      return result; 
    }
