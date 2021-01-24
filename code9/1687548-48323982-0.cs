    using System.Linq;
    ...
    private static IEnumerable<string> EnumerateEnclosed(string value) {
      if (null == value)
        yield break;
      Stack<int> positions = new Stack<int>();
      for (int i = 0; i < value.Length; ++i) {
        char ch = value[i];
        if (ch == '(')
          positions.Push(i);
        else if (ch == ')') 
          if (positions.Any()) {
            int from = positions.Pop();
            if (!positions.Any()) // <- outmost ")"
              yield return value.Substring(from, i - from + 1);
          }
      }
    }
