    var doc = new XDocument(
        new XElement("users",
            from user in users
            select new XElement("user",
                new XAttribute("first-name", user.FirstName ?? ""),
                new XAttribute("last-name", user.LastName ?? ""),
                new XElement("sold-products",
                    from product in user.Products
                    select new XElement("Product",
                        new XElement("name", product.Name),
                        new XElement("price", product.Price))))));
