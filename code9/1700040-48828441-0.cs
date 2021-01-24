    var input = "1,2,3,8,11,12";
    var inputIntegers = input.Split(',').Select(o => Convert.ToInt32(o)).OrderBy(o => o).ToList();
    
    var resultSet = new Dictionary<int, int>();
    foreach (var i in inputIntegers)
    {
      var last = resultSet.LastOrDefault();
      if (!last.Equals(default(KeyValuePair<int, int>)) && last.Value + 1 == i)
      {
          resultSet[last.Key] = i;
      }
      else
      {
          resultSet.Add(i, i);
      }
    }
    
    var parts = resultSet.Select(item =>
    {
      return item.Key != item.Value ? String.Format("{0}-{1}", item.Key, item.Value) : item.Key.ToString();
    });
    var result = String.Join(",", parts);
    Console.WriteLine(result);
    // 1-3,8,11-12
