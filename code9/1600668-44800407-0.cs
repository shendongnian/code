    public IQueryable<Category> GetIQueryable()
    {
        return (from c in entities.categories
                select new Category
                {
                    Code = c.code,
                    Description = c.descripton
    
                }).AsQueryable();
    }
