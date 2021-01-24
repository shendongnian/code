    foreach (var item in bitSanityResults)
    {
      //It looks like you select a string here. Notice that your Dictionary needs int as key!!!
      int key = bitDB.test_suites.Where(x => x.id == item.Key).Select(x => x.suite_name).FirstOrDefault();
      
      if (metrics != null &&
          item != null &&
          item.Value[0] != null &&
          item.Value[1] != null)
      {
         metrics.BitSanity.Add(key, new[] {Convert.ToString(item.Value[0]), Convert.ToString(item.Value[1])});
      }
    }
