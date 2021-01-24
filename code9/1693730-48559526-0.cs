    var json = "{ \"Client\": { \"Name\": \"John\" } }";
    var newJson = string.Empty;
    foreach (var w in json.Split(new[] { "{ \"" }, StringSplitOptions.RemoveEmptyEntries))
    {
        if (w[0] != null)
        {
            newJson += "{ \"" + (w[0].ToString().ToLower()) + w.Remove(0,1);
        }
    }
