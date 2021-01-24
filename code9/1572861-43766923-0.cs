     List<object> ops = m.GroupBy(x => x.Agent).ToList()
     .ConvertAll(c => (object)new { Agent = c.First().Agent});
      list = m
     .GroupBy(x => string.Format(@"""DateText"": {0}", x.DateText ))
     .ToDictionary(x => x.Key, x => x.ToList()
     .ConvertAll(c => (object)new { Datetext = c.DateText,  Agent = c.Agent, 
      Talk = c.Talk  })));
      list.Add("keys", ops);
