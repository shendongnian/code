    using (var db = new BloggingContext())
    {
        var cmd = db.Database.Connection.CreateCommand();
        cmd.CommandText = "[dbo].[GetCategoryAndProductByCategoryId]";
        try
        {
            
            db.Database.Connection.Open();
            // Run the sproc 
            var reader = cmd.ExecuteReader();
            // Read the category from the first result set
            var category = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Category>(
                    reader,
                    "Category",
                    MergeOption.AppendOnly)
                Single();      
            // Move to second result set and read Products
            reader.NextResult();
            var products = ((IObjectContextAdapter)db)
                .ObjectContext
                .Translate<Product>(
                    reader,
                    "Product",
                    MergeOption.AppendOnly);
            category.Products = products;
            return category;
        }
        finally
        {
            db.Database.Connection.Close();
        }
    }
