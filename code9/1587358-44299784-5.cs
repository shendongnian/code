    var test = new InnerList
    {
        intList = new List<InnerList>  {
            new InnerList { isValue = true, val = 1 },
            new InnerList { isValue = true, val = 2 },
            new InnerList
            {
                intList = new List<InnerList>  {
                    new InnerList { isValue = true, val = 13 },
                    new InnerList { isValue = true, val = 23 },
                    new InnerList()
                }
            }
        }
    };
    Console.WriteLine(test);//[1, 2, [13, 23, []]]
