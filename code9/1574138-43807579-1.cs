    namespace so43807152
    {
        struct Record
        {
            public string GTIN;
            public string GTIN_INFO;
            public string WHATEVER;
            public decimal PRICE;
        }
        class Program
        {
            static void Main()
            {
                var stock = new List<Record>();
     
                string[] lines = File.ReadAllLines("stock.txt");
                foreach (var line in lines)
                {
                    var col = line.Split(',');
                    for (int i = 0; i < col.Length; i += 4)
                    {
                        var record = new Record
                        {
                            GTIN = col[i],
                            GTIN_INFO = col[i + 1],
                            WHATEVER = col[i + 2],
                            PRICE = decimal.Parse(col[i + 3])
                        };
                        stock.Add(record);
                    }
                }
            }
        }
    }
