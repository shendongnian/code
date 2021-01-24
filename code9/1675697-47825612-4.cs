    var testBlocks = new List<TestBlock>();
    for (int i = 0; i < b; i++)
    {
        var block = new TestBlock { ... };
        
        for (int j = 0; j < s; j++)
        {
            var street = new TestStreet { ... };
            for (int k = 0; k < d; k++)
            {
                var dut = new DUT { ... };
                street.DUTList.Add(dut);
            }
            block.TestStreetList.Add(street);
        }
        testBlocks.Add(block);
    }
