    dynamic v = new { A = "a" };
    Dictionary<string, object> values = ((object)v)
                                         .GetType()
                                         .GetProperties()
                                         .ToDictionary(p => p.Name, p => p.GetValue(v));
