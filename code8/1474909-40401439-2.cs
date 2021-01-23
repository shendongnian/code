    List<string> splits = "yourSplitsStringArray".ToList();
    //Create your Result Dictionary
    Dictionary<DateTime, string> result = new Dictionary<DateTime, string>();
    
    //Process your data:
    splits.ForEach(x => result.Add(DateTime.Parse(x.Substring(0, 16)), x.Substring(17, x.Length - 17)));
