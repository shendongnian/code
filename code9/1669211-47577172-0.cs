    var ordered = new List<QueryCreatorType>();
    foreach (var item in res)
    {
        if (!ordered.Any(x => x.Table == item.Parent.Table))
        {
            ordered.Add(item.Parent);
        }
        ordered.Add(item);
    }
