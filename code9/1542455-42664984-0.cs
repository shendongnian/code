    foreach (var item in bitSanityResults)
    {
      //It looks like you select a string here. Notice that your Dictionary needs int as key!!!
      int key = bitDB.test_suites.Where(x => x.id == item.Key).Select(x => x.suite_name).FirstOrDefault();
      
      metrics.Add(key, new[] {item.Value1/item.Value2, item.Value1+item.Value2 });
    }
