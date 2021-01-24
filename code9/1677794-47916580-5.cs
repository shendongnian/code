    XNamespace ns = "http://www.google.com/xml/impot//20016-02-31";
    var results = xDocument.Descendants(ns + "impot")
        .SelectMany(impot => impot.Descendants(impot.Name.Namespace + "product-lineitem")
            .Select(item => new {
                ImpotNo = (string)impot.Element(impot.Name.Namespace + "original-impot-no"),
                Price = (string)item.Element(item.Name.Namespace + "price"),
                SmallPrice = (string)item.Element(item.Name.Namespace + "Small-price"),
                BigPrice = (string)item.Element(item.Name.Namespace + "Big-price"),
            })
        ).ToList();
    for (int i = 0; i < results.Count; i++) {
        dataToBeWritten.Append(results[i].ImpotNo);
        dataToBeWritten.Append(";");
        dataToBeWritten.Append(results[i].Price);
        dataToBeWritten.Append(";");
        dataToBeWritten.Append(results[i].SmallPrice);
        dataToBeWritten.Append(";");
        dataToBeWritten.Append(results[i].BigPrice);
        dataToBeWritten.Append(";");
        dataToBeWritten.Append(0);
        dataToBeWritten.Append(Environment.NewLine);
    }
