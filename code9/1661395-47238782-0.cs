    static string RemoveChars(string input, params char[] chars)
    {
      string output = string.Empty;
      for (int i = 0; i < input.Length; i++)
        if (!chars.Contains(input[i]))
          output += input[i];
      return output;
    }
