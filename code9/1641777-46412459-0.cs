    public void DeleteProduct(Product entity)
    {
        if (entity == null) throw new ArgumentNullException("entity");
        entity = _context.Set<Product>().First(f => f.Id == entity.Id);
        _context.Set<Product>().Remove(entity);
        _context.SaveChanges();
    }
