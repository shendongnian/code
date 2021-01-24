    List<TreeNode> taskItems = new List<TreeNode>();
    using (var database = new MyDatabase())
    {
        taskItems =
        (
    		from t in database.Task
    		select new
    		{
    			id = t.ID,
    			text = t.Name,
    			color = t.Color,
    			category = t.Category,
    			parent = t.ParentID
    		}
        )
    	.AsEnumerable()
    	.Select(t => new TreeNode()
    	{
    		id = t.id,
    		text = t.text,
    		attributes = new Dictionary<string, object>()
    		{
    			{ "color", t.color },
    			{ "category", t.category }
    		},
    		parent = t.parent
    	})
    	.ToList();
    }
 
