    var results = xDocument.Descendants("impot")
        .SelectMany(impot => impot.Descendants("product-lineitem")
            .Select(item => new {
                ImpotNo = (string)impot.Element("original-impot-no"),
                Price = (string)item.Element("price"),
                SmallPrice = (string)item.Element("Small-price"),
                BigPrice = (string)item.Element("Big-price"),
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
