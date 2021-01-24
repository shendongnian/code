    var testList = new List<TestBlock>
    {
        new TestBlock
        {
            Name = "name",
            ...
            TestStreetList = new List<TestStreet>
            {
                new TestStreet
                {
                    Name = "name",
                    ...
                    DUTList = new List<DUT>
                    {
                        new DUT { PrimDeviceName = "a", ...  },
                        new DUT { PrimDeviceName = "b", ...  },
                        // repeat
                    }
                },
                new TestStreet
                {
                    // repeat
                }
            }
        },
        new TestBlock
        {
            // repeat
        }
    };
