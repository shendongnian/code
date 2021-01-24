    public class ViewModelProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public int SortOrder { get; set; }
        public List<ViewModelCategoryWithTitle> Categories { get; set; }
    }
    
    var product = (from p in _context.Products
              where p.Id == id
              select new ViewModelProduct
              {
                Id = p.Id,
                Title = p.Title,
                Info = p.Info,
                Price = p.Price,
                Categories = p.InCategories.Select(
                  inCategory=> new ViewModelCategoryWithTitle
                  {
                     CategoryId = inCategory.ProductCategory.Id,
                     Title = inCategory.ProductCategory.Title
                  })
              }).SingleOrDefaultAsync();
