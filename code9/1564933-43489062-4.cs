    string input1 = "bike2car5ship86plan3";
    string input2 = "car382bike50ship92yoyo2";
    var inputs1 = Regex.Matches(input1, "([a-zA-Z]+)([0-9]+)")
      .OfType<Match>()
      .ToDictionary(match => match.Groups[1].Value,
                    match => int.Parse(match.Groups[2].Value));
    var inputs2 = Regex.Matches(input2, "([a-zA-Z]+)([0-9]+)")
      .OfType<Match>()
      .ToDictionary(match => match.Groups[1].Value,
                    match => int.Parse(match.Groups[2].Value));
    TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
    var data = inputs1
      .Where(pair => inputs2.ContainsKey(pair.Key))
      .OrderBy(pair => pair.Key)
      .Select(pair => new {
        Name = textInfo.ToTitleCase(pair.Key),
        Quantity = pair.Value,
        Price = inputs2[pair.Key],
        Total = pair.Value * inputs2[pair.Key],
      })
      .ToArray();
    string table = string.Join(Environment.NewLine, data
      .Select(item => string.Format("{0,-5} {1,3} x {2,3} = {3,4}",
         item.Name, item.Quantity, item.Price, item.Total)));
    string result = string.Join(Environment.NewLine, 
      table, 
      new string('-', 25), 
      string.Format("Total = {0}", data.Sum(pair => pair.Total)));
    Console.Write(result);
