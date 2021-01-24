    database.Task
    .Select(t=> new 
    {
                t.ID,
                t.Name,
                t.Color,
                t.Category,
                t.ParentID
    }).AsEnumerable()
    .Select(t=> new TreeNode
            {
                id = t.ID,
                text = t.Name,
                attributes = new List<KeyValuePair<string, object>>
                {
                    new KeyValuePair<string, object>("Color", t.Color),
                    new KeyValuePair<string, object>("Category", t.Category)
                },
                parent = t.ParentID
            }).ToList()
