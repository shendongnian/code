    public List<ProductItem> LoadData(csvPath)
    {
        String[] csv = File.ReadAllLines(csvPath);
        List<ProductItem> result = new List<ProducItem>();
        foreach (string csvrow in csv)
        {
            var fields = csvrow.Split(',');
            ProductItem prod = new ProductItem()
            {
                ID = Convert.ToInt32(fields[0]),
                Description = fields[1],
                Item = fields[2][0],
                Price = Convert.ToDecimal(fields[3]),
                ImagePath = fields[4],
                Barcode = fields[5]
            });
            result.Add(prod);
        }
        return result;
    }
