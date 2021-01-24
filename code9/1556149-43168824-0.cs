    foreach (var user in users)
    {
        var soldProducts = new XElement("sold-products");
        xml.Add(new XElement("user",
            new XAttribute("first-name", user.FirstName?? ""),
            new XAttribute("last-name", user.LastName?? ""),
            soldProducts));
        foreach (var product in user.Products)
        {
            soldProducts.Add(new XElement("Product",
                new XElement("name", product.Name),
                new XElement("price", product.Price)));
        }
    }
