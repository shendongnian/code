    var cpics = _context.ProductsInCategories;
    var vmc = from pc in _context.ProductCategories
              where pc.ParentId == null
              orderby pc.SortOrder
              select new ViewModelProductCategory(pc, cpics);
    public class ViewModelProduct
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Info { get; set; }
        public decimal Price { get; set; }
        public int SortOrder { get; set; }
        public IEnumerable<ViewModelCategoryWithTitle> Categories { get; set; }
        public ViewModelProduct(ProductInCategory pic)
        {
            Id = pic.Product.Id;
            Title = pic.Product.Title;
            Price = pic.Product.Price;
            Info = pic.Product.Info;
            SortOrder = pic.SortOrder;
        }
        public ViewModelProduct() { }
    }
    public class ViewModelProductCategory
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Title { get; set; }
        public int SortOrder { get; set; }
        public string ProductCountInfo =>
            Products != null && Products.Any() ? Products.Count().ToString() : "0";
        public ProductCategory ParentCategory { get; set; } // Nav.prop. to parent
        public IEnumerable<ProductCategory> Children { get; set; } // Nav.prop. to children
        public List<ViewModelProduct> Products { get; set; } // Products in this category
        public List<ViewModelProduct> OrphanProducts { get; set; } // Products with no references in ProductInCategory
        public ViewModelProductCategory(ProductCategory pc, IEnumerable<ProductInCategory> cpics)
        {
            Id = pc.Id;
            Children = pc.Children;
            ParentId = pc.ParentId;
            Title = pc.Title;
            SortOrder = pc.SortOrder;
            OrphanProducts = (from pcpic in pc.ProductInCategory
                              join cpic in cpics
                                  on pcpic.Id equals cpic.ProductId
                                  into pics
                              from pic in pics.DefaultIfEmpty()
                              where pic == null
                              select new ViewModelProduct(pcpic))
                             .OrderBy(s => s.SortOrder)
                             .ToList();
        }
        public ViewModelProductCategory() { }
    }
