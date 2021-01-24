      string[] items = text
        .Split('x')
        .Select(item => item
           .Replace("'", "*12")
           .Replace("-", "+")
           .Replace("x", "+")
           .Replace(" ", "+")
           .Replace(@"""", ""))
        .Select((v, i) => $"{(char)('a' + i)} = ({v})")
        .ToArray();
      string formula = 
        string.Join(Environment.NewLine, items) + Environment.NewLine +
        $"{(char) ('a' + items.Length)} = " +
        string.Join(" + ", Enumerable.Range('a', items.Length).Select(c => $"{(char) (c)}"));
      Console.Write(formula);
