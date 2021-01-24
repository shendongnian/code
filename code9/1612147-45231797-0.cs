    List<int> list = model
       .Categories
       .Split(',')
       .Select(item => {
          int value;
          bool parsed = int.TryParse(item, out value);
    
          return new {
            parsed = parsed,
            value = value;
          };
        })
       .Where(item => item.parsed)
       .Select(item => item.value)
       .ToList();
