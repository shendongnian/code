    //...
    var results = xDocument.Descendants("impot")
        .Select(x => new {
            ImpotNo = (string)x.Attribute("impot-no"),
            Price = (string)x.Element("price"),
            SmallPrice = (string)x.Element("Small-price"),
            BigPrice = (string)x.Element("Big-price"),
        }).ToList();
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
    //...
