    List<string> models = new List<string>
    {
        "abcd1234",
        "xycd9999",
        "zzz999z",
        "ros7777"
    };
    List<string> filterer = new List<string>
        {
            "cd",
            "9999"
        };
                    var predicate = PredicateBuilder.False<string>();
    
                    foreach (string filter in filterer)
                    {
                        predicate = predicate.Or(f => f.Contains(filter));
                   
                    }
                   
                        var filteredList = models.AsQueryable().Where(predicate).ToList();
