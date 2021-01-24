        public static string _ExtractFoo(ProductService.Customer customer)
        {
            return customer.DoSomethingExciting();
        }
    You would have this:
        public static string _ExtractFoo(dynamic customer)
        {
            return customer.DoSomethingExciting();
        }
    You could, if you wanted, add some checking to ensure that `customer` is either `ProductService.Customer` or `CoreService.Customer` if you want some safety.
