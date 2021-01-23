    var dictionary = new Dictionary<string, List<DateTime>>();
    dictionary.Add("cat", new List<DateTime>{DateTime.Now, DateTime.Now.AddDays(1)});
    if (dictionary.ContainsKey("cat"))
    {
        var dates = dictionary["cat"];
        //now you have access to those dates
    }
