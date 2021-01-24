    var list = new List<List<string>>();
    foreach (var row in DataRowCollection) {
        var subList = new List<string>();
        foreach (var item in row.ItemArray)
            subList.Add(item.ToString());
        list.Add(subList);
    }
