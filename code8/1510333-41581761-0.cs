    using (DefaultSoapClient client = new DefaultSoapClient())
    {
        client.Login("login", "password", null, null, null);
        try
        {
            var items = client.GetList(
            new StockItem
            {
                RowNumber = new LongSearch
                {
                    Condition = LongCondition.IsLessThan,
                    Value = 10
                }
            },
            false);
            int count = items.Length;
            Console.WriteLine("InventoryID | Description | ItemClass | BaseUOM | LastModified");
            foreach (StockItem stockItem in items)
            {
                Console.WriteLine(
                    string.Format("{0} | {1} | {2} | {3} | {4}",
                        stockItem.InventoryID.Value,
                        stockItem.Description.Value,
                        stockItem.ItemClass.Value,
                        stockItem.BaseUOM.Value,
                        stockItem.LastModified.Value));
            }
            while (items.Length == 10)
            {
                StockItem filter = new StockItem
                {
                    RowNumber = new LongSearch
                    {
                        Condition = LongCondition.IsLessThan,
                        Value = 10
                    },
                    InventoryID = new StringSearch
                    {
                        Condition = StringCondition.IsGreaterThan,
                        Value = (items[items.Length - 1] as StockItem).InventoryID.Value
                    }
                };
                items = client.GetList(filter, false);
                count = count + items.Length;
                foreach (StockItem stockItem in items)
                {
                    Console.WriteLine(
                        string.Format("{0} | {1} | {2} | {3} | {4}",
                            stockItem.InventoryID.Value,
                            stockItem.Description.Value,
                            stockItem.ItemClass.Value,
                            stockItem.BaseUOM.Value,
                            stockItem.LastModified.Value));
                }
            }
            Console.WriteLine();
            Console.WriteLine(string.Format("Stock Items exported: {0}", count));
            Console.WriteLine();
        }
        finally
        {
            client.Logout();
        }
    }
