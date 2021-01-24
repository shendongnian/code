    public void WriteToCsv(string csvPath, List<ProductItem> products)
    {
        List<string> lines = new List<string>();
        foreach(ProductItem item in products)
        {
            string line = string.Join(",", item.ID.ToString(), 
                                           item.Description, 
                                           item.Item.ToString(),
                                           item.Price.ToString(), 
                                           item.ImageCode,
                                           item.BarCode);
            lines.Add(line);
       }
       File.WriteAllLines(csvPath, lines);
    }
