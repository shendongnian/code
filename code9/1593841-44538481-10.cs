    List<double[]> example = new List<double[]>();
                        
    while (!reader.EndOfStream)
    {
        example.Add(reader.ReadLine()
          .Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries)
          .Where(item => !string.Equals("NAN", item, StringComparison.OrdinalIgnoreCase))
          .Where(items => items.Any())
          .Select(item => double.Parse(item.ToString(), CultureInfo.InvariantCulture)).ToArray());
    }
    
    
    var returnvalue = example.ToArray();
    
