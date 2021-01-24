    customers
        .Where(cust => cust.CustomerMarket == "GB")
        .Select(cust => new
        {
            cust.CustomerId,
            cust.CustomerName,
            ApplianceCount = products
                .Where(prod => prod.CustomerId == cust.CustomerId && prod.Category == "HomeAppliance")
                .Select(prod => prod.ProductId)
                .Count(),
            FurnishingCount = products
                .Where(prod => prod.CustomerId == cust.CustomerId && prod.Category == "Furnishing")
                .Select(prod => prod.ProductId)
                .Count(),
        });
