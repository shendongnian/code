    var data = fakeXML.SelectMany(selector => {
        XDocument doc = XDocument.Parse(selector);
        return from q in doc.Descendants("Data")
               select new {
                   Time = q.Element("Time").Value,
                   NetSales = decimal.Parse(q.Element("NetSales").Value),
                   NetReturns = decimal.Parse(q.Element("NetReturns").Value),
                   NetIncome = decimal.Parse(q.Element("NetIncome").Value),
                   CustCount = int.Parse(q.Element("CustomerCount").Value),
                   PercentOfIncome = double.Parse(q.Element("PercentOfIncome").Value)
               };
    });
    var summary = data.GroupBy(d => d.Time)
        .Select(g => new {
            Time = g.Key,
            NetSales = g.Sum(d => d.NetSales),
            NetReturns = g.Sum(d => d.NetReturns),
            NetIncome = g.Sum(d => d.NetIncome),
            CustCount = g.Sum(d => d.CustCount),
        });
    }
