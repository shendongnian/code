    [DelimitedRecord(",")]
    class Product : INotifyWrite
    {
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Name;
        [FieldQuoted(QuoteMode.AlwaysQuoted)]
        public string Description;
        [FieldOptional]
        public string Size;
        public void BeforeWrite(BeforeWriteEventArgs e)
        {
            // prevent output of [FieldOptional] Size field
            Size = null;
        }
        public void AfterWrite(AfterWriteEventArgs e)
        {
            // remove last "delimiter"
            e.RecordLine = e.RecordLine.Remove(e.RecordLine.Length - 1, 1);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var engine = new FileHelperEngine<Product>();
            var products = new Product[] { new Product() { Name = "Product", Description = "Details", Size = "Large"} };
            var productRecords = engine.WriteString(products);
            try
            {
                // Make sure Size field is not part of the output
                Assert.AreEqual(@"""Product"",""Details""" + Environment.NewLine, productRecords);
                Console.WriteLine("All tests pass");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred");
                Console.WriteLine(ex);
            }
            
            Console.ReadKey();
        }
    }
