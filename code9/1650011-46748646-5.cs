    public static class ProductExtension
    {
        public static Product FixProduct(this Product input)
        {
            return new Product
                {
                    Name = input.Name.ToUpper(),
                    Id = input.Id
                }
            //product.Name is now UPPERCASE
        }
    }
