    public static async Task SaveProducts()
            {
    
                foreach (var category in CategoriesList)
                {
                    foreach (var product in ProductsList)
                    {
                        
                        if (product.CategoryName == category.Name)
                        {
                            category.Products.Add(product);
                        }
                    }
    
                    db.Categories.Add(category);
                }
    
                await db.SaveChangesAsync();
            }
