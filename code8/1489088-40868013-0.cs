      // please, think about variables' names: what is "n", "s"?  
      string text = Console.ReadLine();
      // be nice: allow double spaces, take tabulation into account
      string[] words = text.Split(new char[] { ' ', '\t' },
        StringSplitOptions.RemoveEmptyEntries);
      // Linq is often terse and readable
      int maxLength = words.Max(word => word.Length);
      string top = new string('*', maxLength + 2);
      string body = string.Join(Environment.NewLine, words
        .Select(word => "*" + word.PadRight(maxLength) + "*"));
      string result = string.Join(Environment.NewLine, top, body, top);
      // final output
      Console.Write(result);
