    var xFeed = 
        new XElement("Feed",
            new XAttribute("xmlns", settings.bvXMLConfig.xmlns),
            new XAttribute("name", settings.bvXMLConfig.xmlName),
            new XAttribute("incrmental", settings.bvXMLConfig.xmlIncremental),
            new XAttribute("extractDate", DateTime.UtcNow)
        );
    var xProducts = new XElement("Products");
    xFeed.Add(xProducts);
    foreach (ProductSearchModel prod in prods)
    {
        var xProduct = 
            new XElement("Product",
                new XElement("ExternalId", prod.SKU),
                new XElement("Name", prod.Description.Name),
                new XElement("Description", prod.Description.Description),
                new XElement("BrandExternalID", prod.Properties.Brand.FeedName),
                new XElement("CategoryExternalId"), //look up the category here by sku
                new XElement("ModelNumbers",
                    new XElement("ModelNumber", prod.SKU)),
                new XElement("ManufacturingPartNumbers",
                    new XElement("ManufacturingPartNumber", prod.SKU)),
                new XElement("UPCs",
                    new XElement("UPC", prod.UPC)),
                new XElement("Attributes"),
                new XElement("Attribute",
                    new XAttribute("id", "BV_FE_FAMILY"),
                    new XElement("Value"))
            );
        xProducts.Add(xProduct);
    }
