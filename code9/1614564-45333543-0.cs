    var counts = ctx.Posts
    	.Select(po => new { po.Tag })
    	.Where(po => po.Tag != null)
    	.GroupBy(po => new
    	{
    		Tag = po.Tag.Name,
    		Category = po.Tag.Category.Name ?? "Other"
    	})
    	.Select(agg => new
    	{
    		NumberOfPosts = agg.Count(),
    		Tag = agg.Key.Tag,
    		Category = agg.Key.Category
    	})
    	.ToList();
