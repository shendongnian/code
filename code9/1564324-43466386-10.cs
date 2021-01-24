    string formula;
    using (DataTable dt = new DataTable()) {
      string[] items = text
        .Split('x')
        .Select(item => item
           .Replace("'", "*12")
           .Replace("-", "+")
           .Replace("x", "+")
           .Replace(" ", "+")
           .Replace(@"""", ""))
        .ToArray();
      formula = 
        string.Join(Environment.NewLine, items
          .Select((v, i) => $"{(char) ('a' + i)} = ({v}) = {dt.Compute(v, null)}")) +
        Environment.NewLine +
        $"{(char) ('a' + items.Length)} = " +
        string.Join(" + ", Enumerable.Range('a', items.Length).Select(c => $"{(char) (c)}")) + 
        $" = {items.Sum(item => Convert.ToDecimal(dt.Compute(item, null)))}";
    }
    Console.Write(formula);
