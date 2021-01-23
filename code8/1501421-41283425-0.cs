    var outputs=  new List<string>();
    foreach (var item in input)
    {
        var splitted = item.Split(',');
        foreach (var splt in splitted)
        {
            if (splt != "N/A")
            {
                outputs.Add(splt);
            }
        }
    }
