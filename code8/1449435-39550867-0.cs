    var list = db.Teams.ToList();
    int index = list.FindIndex(t => t.Name == "Total");
    if (index >= 0 && index != list.Count - 1)
    {
        var total = list[index];
        list.RemoveAt(index);
        list.Add(total);
    }
