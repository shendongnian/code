     List<string> x = new List<string>() { "", "pp", "jj", "kjj", "", "" };
     foreach (string s in x.Select(xx => string.IsNullOrEmpty(xx) ? "Empty" : "Populated"))
     {
         Console.WriteLine(s);
     }
