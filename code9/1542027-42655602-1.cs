    // using Z.EntityFramework.Plus; // Don't forget to include this.
    var ctx = new EntitiesContext();
    
    ctx.Filter<Post>(q => q.Where(x => !x.IsSoftDeleted));
    
    // SELECT * FROM Post WHERE IsSoftDeleted = false
    var list = ctx.Posts.ToList();
