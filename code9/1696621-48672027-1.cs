    public class ProductMocks
    {
        private IList<Products> _ProductList;
        public IList<Products> ProductList
        {
            get
            {
                if(_ProductList == null)
                {
                   _ProductList  = new List<Products>
                    {
                        new Products
                        {
                            Id = 1,
                            Name = "Some Data",
                            Price = 34.00
                        },
                        new Products
                        {
                            Id = 2,
                            Name = "More Data",
                            Price = 28.00
                        }
                    };
                 }
                 
                 return _ProductList;
            }
        }
    }
