      List<string> lst = new List<string>();
      lst.Add("A");
      lst.Add("A");
      var X = new Dictionary<string, List<object>>();  // note this type
      foreach (var a in lst)
      {
        List<object> li;
        if (X.TryGetValue(a, out li))
        {
          li.Add(10);
        }
        else
        {
          X.Add(a, new List<object> { "hello", });
        }
      }
