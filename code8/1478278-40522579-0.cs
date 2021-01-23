    IEnumerable<decimal> prices = new List<decimal>() { 100, 200, 300 };
    decimal discountPercentage = 20;
    
    // calculate prices after applying the discount via LINQ
    prices = prices.Select(p => (100 - discountPercentage) / 100 * p);  
            
    // displaying for testing purposes     
    foreach (decimal price in prices)
    {
        Console.WriteLine(price);
    }
