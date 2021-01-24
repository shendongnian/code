    public class PrintRequest
    {
        public Product Product { get; }
        public Customer Customer { get; set; }
        public int? OrdinalNumber { get; set; }
        public PrintRequest(Product product)
        {
             if(product = =null)
                 throw new ArgumentNullException(nameof(product));
             Product = product;
        }
    }
    public static bool PrintSomething(PrintRequest printRequest)
