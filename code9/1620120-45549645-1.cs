    var productFiles = new List<ProductFile>();
    foreach (string file in fileList)
    {
        var productFile = new ProductFile();
        using (StreamReader sr = new StreamReader(file))
        {
            string line;
            while ((line = sr.ReadLine()) != null)
            {
                rows++;
                if (line.StartsWith("Product"))
                {
                    var val = line.Split(',');
                    var product = new Product()
                    {
                        Upc = val[1],
                        PName = val[3]
                    };
                    productFile.Products.Add(product);
                }
            }
        };
        productFiles.Add(productFile);
    }
