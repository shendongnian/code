    using(var context = new HierarchyContext())
    {
	    var depth = context
					.Categories
					.IncludeHierarchy(3, nameof(Category.Children));
		var root = depth.Single(c => c.Id == 2);
	}
    public static IQueryable<T> IncludeHierarchy<T>(this IQueryable<T> source, 
    uint depth, string propertyName)
    where T : Category
    {
    	var temp = source;
    
    	for (var i = 1; i <= depth; i++)
        {
    	    var sb = new StringBuilder();
    
    	    for (var j = 0; j < i; j++)
            {
    		    if (j > 0)
                {
    			    sb.Append(".");
    		    }
    
    		    sb.Append(propertyName);
    	    }
    
    	    var path = sb.ToString();
    
    	    temp = temp.Include(path);
        }
    
        var result = temp;
    
        return result;
    }
    public class Category
    {    
       // Primary key    
       public int Id { get; set; }
    
       // Category name    
       public string Name { get; set; }
    
       // Foreign key relationship to parent category    
       public int ParentId { get; set; }
    
       // Navigation property to parent category    
       public virtual Category Parent { get; set; }
    
       // Navigation property to child categories    
       public virtual ICollection<Category> Children { get; set; }    
    }
