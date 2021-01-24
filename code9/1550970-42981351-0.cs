    public IEnumerable<CategoryStatsVM> GetCategoryStats() 
    {
        IList<Category> categories = dbContext.Categories.Include(m => m.Products).ToList();
        foreach (Category category in categories)
        {
            yield return new CategoryStatsVM
            {
                Name = category.Name,
                Count = category.Products.Count(),
                Products = this.GetProducts(category.Products),
                MinPrice = category.Products.Aggregate(GetMinPrice),
                MaxPrice = category.Products.Aggregate(GetMaxPrice) 
            }
        }
    }
    private Product GetMinPrice(Product min, Product current)
    {
        return min == null || curr.Price < min.Price ? curr : min;
    }
    private Product GetMaxPrice(Product max, Product current)
    {
        return max == null || curr.Price > max.Price ? curr : max;
    }
    private IEnumerable<ProductVM> GetProducts(IEnumerable<Product> products)
    {
        List<ProductVM> products; // create instance of the product view model list
        return products;
    }
