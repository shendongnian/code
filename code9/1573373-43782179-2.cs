      foreach (var a in lst)
      {
        List<object> li;
        var oldKey = X.TryGetValue(a, out li);
        if (!oldKey)
        {
          li = new List<object>(1);
          X.Add(a, li);
        }
        li.Add(oldKey ? (object)10 : "hello");
      }
