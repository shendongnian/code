    AllBuyers.Join(AllInvoices, 
                a => a.BuyerIdentifier, 
                a => a.BuyerID, 
                (b, i) => new { Buyer = b, Invoice = i })
        .Where(a => a.Buyer.Name.Contains("name"))
        .Select(a => a.Invoice).ToList();
