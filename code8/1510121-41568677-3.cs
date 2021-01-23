    public class Product
    {
        public async Task UpdateProductAsync(int productId,int UserId)
        {
            Category cat = new Category();
            // this need to be changed to async too
            var categories = await cat.GetCategoryAsync(); 
            foreach(var category in categories)
            {
                // process result of GetCategoryAsync
            }
        }
    }
