    private static void CreateDoc()
        {
            // Store the Service element is a variable so we can add stuff to it
            XElement serviceElement = new XElement("Service");
            XElement rootElement = new XElement("Catalog", serviceElement); //Create the root Element 
            // Obviously include the foreach loop
            //foreach (....)// Logic for multiple product element 
            // Obviously replace these hardcoded string with your actual object values
            XElement productElement = new XElement("Product", new XAttribute("name", "someProduct"));//Read the Product
            XElement variantElement = new XElement("Variant", new XAttribute("name", "someVariant"));//Read variant
            XElement skuElement = new XElement("SKU", new XAttribute("name", "someSKU"));//Read SKU
            productElement.Add(variantElement, skuElement);//Add varaint and skuvariant to product
            // Add product to the Service element, NOT to the root. The root is Catalog.
            serviceElement.Add(productElement);
            rootElement.Save("XmlFile.xml");
        }
