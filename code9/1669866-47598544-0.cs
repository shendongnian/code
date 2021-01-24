    foreach (var k in cars.Keys)
    {
        List<string> ls = cars[k];
        var car = ls.FirstOrDefault(c => c.ToLowerInvariant() == "chevy".Trim().ToLowerInvariant());
        if (car != null)
        {
            ls.Remove(car);
            if (ls.Count == 0)
            {
               cars.Remove(k);
            }
            break;
        }
    }
      
