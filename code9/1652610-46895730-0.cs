     var text = File.ReadAllText("C:\\johndoe.txt");
     var sw = new StreamWriter("C:\\johndoeduplicates.txt");
     var splits = text.Split('|')
     .Select(m => new KeyValuePair<string, string>(m.Substring(14, 2), m))
     .GroupBy(z => z.Key)
     .Where(y => y.Count() > 1);
      foreach (var x in splits)
      {  
          foreach (var y in x)
           sw.WriteLine(y.Value);
      }
      sw.Close();
