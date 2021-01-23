    namespace ProductServiceClient.ServiceReference1
    {
        public partial class Product
        {
            public decimal SomeProperty
            {
                get
                {
                    return this.Price * 10;
                }
            }
        }
    }
