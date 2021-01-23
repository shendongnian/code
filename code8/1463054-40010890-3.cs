    public static SalesInfo Parse(string stringValue)
    {
        string[] words;
        SalesInfo salesInfo = new SalesInfo();
        words = StringMethods.ParseCsvString(stringValue.Trim());
        salesInfo.ID = int.Parse(words[0]);
        salesInfo.Name = words[1];
        salesInfo.City = words[2];
        // Solution here
        salesInfo.Senior = words[3].Trim().ToLower().Equals("y");
        salesInfo.Veteran = bool.Parse(words[4]);
        salesInfo.PurDate = Date.Parse(words[5]);
        salesInfo.ItemPrice = Double.Parse(words[6]);
        salesInfo.Quantity = int.Parse(words[7]);
        return salesInfo;
    }
