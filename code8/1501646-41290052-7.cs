    public class Product
        {
            public string ProductName { get; set; }
            public string VariantName { get; set; }
            public string SKU { get; set; }
        }
        private static void CreateDoc(List<Product> list)
        {
            XElement serviceElement = new XElement("Service");
            XElement rootElement = new XElement("Catalog", serviceElement);//Create a root Element 
            // Obviously include the foreach loop
            foreach (Product product in list)
            {
                // Obviously replace these hardcoded string with your actual object values
                XElement productElement = new XElement("Product", new XAttribute("name", product.ProductName));//Read the Product
                XElement variantElement = new XElement("Variant", new XAttribute("name", product.VariantName));//Read variant
                XElement skuElement = new XElement("SKU", new XAttribute("name", product.SKU));//Read SKU
                productElement.Add(variantElement, skuElement);//Add varaint and skuvariant to product
                // Add product to the Service element, NOT to the root. The root is Catalog.
                serviceElement.Add(productElement);
            }
            rootElement.Save("XmlFile.xml");
        }
