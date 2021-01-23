    private static Dictionary<char, char> openByClose = new Dictionary<char, char>() {
      { '}', '{' }, 
      { ']', '[' }, 
      { ')', '(' },
    };
    private static bool IsBalanced(string source) {
      if (string.IsNullOrEmpty(source))
        return true;
      Stack<char> brackets = new Stack<char>();
      foreach (char ch in source) {
        char open;
        if (openByClose.Values.Contains(ch)) // ch is an opening bracket
          brackets.Push(ch);
        else if (openByClose.TryGetValue(ch, out open)) // ch is a closing bracket
          if (!brackets.Any())
            return false; // too many closing brackets, e.g. "())"
          else if (brackets.Pop() != open)
            return false; // brackets don't correspond, e.g. "(]"
      }
      return !brackets.Any(); // too many opening brackets, e.g. "(()"
    }
    
