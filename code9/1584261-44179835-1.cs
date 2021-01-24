    List<TreeNode> taskItems = new List<TreeNode>();
    using (var database = new MyDatabase())
    {
        taskItems =
        (
            from t in database.Task
            select new TreeNode()
            {
                id = t.ID,
                text = t.Name,
                attributes = new List<KeyValuePairCustom<string, object>>()
                {
                    new KeyValuePairCustom<string, object>() { 
                        Key="Color", 
                        Value = t.Color
                    },
                    new KeyValuePair<string, object>() {
                        Key = "Category", 
                        Value = t.Category
                    }
                },
                parent = t.ParentID
            }
        )
        .ToList();
    }
