    reader.ReadLine()
          .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
          .Where(item => !string.Equals("NAN", item, StringComparison.OrdinalIgnoreCase))
          .Where(items => items.Any())
          .Select(items => items.Select(item => double.Parse(item.ToString())).ToArray()).ToArray();
