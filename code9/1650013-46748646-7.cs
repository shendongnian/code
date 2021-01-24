    public static class ProductExtension
    {
        public static T FixProduct<T>(this T input) where T: Product, new
        {
            return new T
                {
                    Name = input.Name.ToUpper(),
                    Id = input.Id
                }
        }
    }
