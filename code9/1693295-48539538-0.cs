      dict.Add(1, "This is the first line.");
      dict.Add(2, "This is the second line.");
      dict.Add(3, "This is the third line.");
      string result = dict
        .OrderBy(pair => pair.Key)
        .Aggregate((StringBuilder) null, 
                   (sb, pair) => (sb == null 
                      ? new StringBuilder() 
                      : sb.Append(Environment.NewLine)).Append(pair.Value))
        .ToString();
