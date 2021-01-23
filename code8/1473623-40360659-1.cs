    using (ProductContext dataContext = new ProductContext())
                {
                    var removeProd = dataContext.ProductData.Where(a => a.Id == prodId).FirstOrDefault();
                    dataContext.ProductData.Remove(removeProd);
    
                    dataContext.SaveChanges();
                    return "Product Removed";
                }
