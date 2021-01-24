    //TODO: I suggest combining starts and ends into array of pairs, e.g.
    // KeyValuePair<string,string>[]
    private static string CutOffComments(string source, char[] starts, char[] ends) {
      if (string.IsNullOrEmpty(source))
        return source;
      StringBuilder sb = new StringBuilder(source.Length);
      int commentIndex = -1;
      foreach (var c in source) {
        if (commentIndex >= 0) { // within a comment, looking for its end
          if (c == ends[commentIndex])
            commentIndex = -1;
        }
        else { // out of comment, do we starting a new one?
          commentIndex = Array.IndexOf(starts, c);
          if (commentIndex < 0)
            sb.Append(c);
        }
      }
      //TODO:
      // if (commentIndex >= 0) // dungling comment, e.g. 123[456
      return sb.ToString(); 
    }
