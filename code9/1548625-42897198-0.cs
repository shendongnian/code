     string input = "heLLoWorLd";
     StringBuilder builder = new StringBuilder();
     StringBuilder upp = new StringBuilder();
     StringBuilder low = new StringBuilder();
     foreach (char c in input)
     {
      if (Char.IsLower(c))
       {
        low.Append(c);
       }
    }
    foreach (char c in input)
      {
      if (Char.IsUpper(c)){
          upp.Append(c);
      } 
    }
    string output = low.ToString() + upp.ToString();
