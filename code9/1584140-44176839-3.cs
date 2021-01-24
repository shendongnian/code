    class Program
    {
        public static void Main(string[] args)
        {
            List<ModelClass> productList = new List<ModelClass>();
            var product1 = new ModelClass();
            product1.Name = "Name1";
            product1.Search = "Search1";
            productList.Add(product1);
            var product2 = new ModelClass();
            product2.Name = "Name2";
            product2.Search = "Search2";
            productList.Add(product2);
            var product3 = new ModelClass();
            product3.Name = "Name3";
            product3.Search = "Search3";
            productList.Add(product3);
            TestClass obj = new TestClass();
            obj.Property1 = "p1";
            obj.Property2 = "p2";
            obj.Property3 = "p3";
            obj.Property4 = "p4";
            obj.ProductList = productList;
            XmlSerializer xmlSerializer = new XmlSerializer(obj.GetType());
            using (StringWriter textWriter = new StringWriter())
            {
                xmlSerializer.Serialize(textWriter, obj);
                string xmlString = textWriter.ToString();
                Console.WriteLine(textWriter);
            }
            Console.ReadKey();
        }
    }
