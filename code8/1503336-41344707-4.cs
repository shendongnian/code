    var query = data;
    foreach (var criterion in criteria.Values){
      query = query.Where(user => !criterion(user));
    }
    var restAvg = query.Average(user => user.Testval);
    var count = query.Count();
