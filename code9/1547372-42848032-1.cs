    var products = new List<Product>();
    
    using (var fileStream = new FileStream("product.txt", FileMode.OpenOrCreate, FileAccess.Read))
    using (var streamReader = new StreamReader(fileStream))
    {
        string line;
        while (!String.IsNullOrWhiteSpace((line = streamReader.ReadLine())))
        {
            if (!line.StartsWith("//"))
            {
                var lineSplit = line.Split(';');
                products.Add(new Product
                {
                    Code = lineSplit[0],
                    Name = lineSplit[1],
                    Price = Decimal.Parse(lineSplit[2]),
                    Stock = Int32.Parse(lineSplit[3])
                });
            }
        }
    }
