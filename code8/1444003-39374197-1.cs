    using (var context = new MyDbContext())
    {
        var parent = context.Parents.Find(parentId);
        //or use LINQ if you prefer:
        var alternative = context.Parents.Single(p => p.Id == parentId)
        foreach(var child in parent.Children.ToList())
        {
            context.Children.Remove(child);
        }
        context.Parents.Remove(parent);
    
        context.SaveChanges();
    }
