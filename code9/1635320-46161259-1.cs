    public override IEnumerable<Category> GetAll()
    { 
        return Table
           .Include(x => x.Children)
           .AsEnumerable()
           .Where(x => x.Parent == null)
           .ToList();
    }
