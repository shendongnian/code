    public ActionResult Index()
    {
        var cats = CategoryDetails();
        var result = (from c in db.Products
                      select new ProductDetails
                      {
                         ProductName = c.ProductName,
                         Price = c.Price,
                         Categories = cats 
                      }).ToList();
    
         return View(result);
    }
    
    public List<CategoryList> CategoryDetails()
    {
        List<CategoryList> result = aGateway.GetAllCategories().ToList();
        return result;
    }
