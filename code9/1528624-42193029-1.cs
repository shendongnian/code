    // GETAll api/category
    public IEnumerable<Category> GetAll() {
        using(var db = new nopMass()) {
  
            var cats = db.Categories
                        .Where(x => x.ParentCategoryId == 0)
                        .AsEnumerable()
                        .Select(cat => new Category { 
                            ParentCategoryId = cat.ParentCategoryId, 
                            Name = cat.Name 
                         })
                        .ToArray();
            
            return cats;
        }
    }
