    static ICollection<TreeModelJson> MapToTreeModelJsonCollection(ICollection<TreeModel> source)
    {
        // map all items
        var allItems = source.Select(e => new TreeModelJson
        {
            ChangeFlowsFromParent = e.ChangeFlowsFromParent.ToString().ToLower(),
            ChangeFlowsToParent = e.ChangeFlowsToParent.ToString().ToLower(),
            Compliance = e.Compliance,
            Parent = e.Parent ?? "none",
            StreamName = e.StreamName,
            StreamType = e.StreamType,
        }).ToList();
        // build tree structure
        foreach (var item in allItems)
        {
            var children = allItems.Where(e => e.Parent == item.StreamName).ToList();
            if (children.Any())
            {
                item.Children = children;
            }
        }
        // return only root items
        return allItems.Where(e => e.Parent == "none").ToList();
    }
