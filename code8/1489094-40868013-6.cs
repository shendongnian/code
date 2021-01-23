      // please, think about variables' names: what is "n", "s"? 
      // longest is NOT the longest word, but maxLength  
      string text = Console.ReadLine();
      // be nice: allow double spaces, take tabulation into account
      string[] words = text.Split(new char[] { ' ', '\t' },
        StringSplitOptions.RemoveEmptyEntries);
      // Linq is often terse and readable
      int maxLength = words.Max(word => word.Length);
      // try keep it simple (try avoiding complex coding)
      // In fact, we have to create (and debug) top
      string top = new string('*', maxLength + 2);
      // ...body... :
      // for each word in words we should
      //   - ensure it has length of maxLength - word.PadRight(maxLength)
      //   - add *s at both ends: "*" + ... + "*"    
      string body = string.Join(Environment.NewLine, words
        .Select(word => "*" + word.PadRight(maxLength) + "*"));
      // and, finally, join top, body and top 
      string result = string.Join(Environment.NewLine, top, body, top);
      // final output
      Console.Write(result);
