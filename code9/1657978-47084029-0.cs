    var xdoc = XDocument.Parse(xml);
    var headersWithItems = 
        xdoc.Descendants("Header")
        .Select(h => new {
            Header = h,
            Items = h.ElementsAfterSelf().TakeWhile(e => e.Name == "Item") })
        ;
    var salesOrders =
        new XElement("SalesOrders",
            headersWithItems.Select(
                    hwi =>
                    {
                        var e = new XElement("Order", hwi.Header);
                        e.Add(hwi.Items.ToArray());
                        return e;
                    }
                ).ToArray()
            );
