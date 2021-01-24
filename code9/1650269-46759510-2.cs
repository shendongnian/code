    // SortTest elements are read from the XML named SortTestDataSource.xml
    [TestMethod]
    [DataSource("Microsoft.VisualStudio.TestTools.DataSource.XML", "|DataDirectory|\\SortTestDataSource.xml", "SortTest", DataAccessMethod.Sequential)]
    public void SortTest()
    {
        var reflist = Enumerable.Range(0, 100);
        // And you can read the XML attributes of each row as follows 
        int count = Int32.Parse((string)TestContext.DataRow["Count"]);
        SortingAlgorithm algorithm = (SortingAlgorithm)Enum.Parse(typeof(SortingAlgorithm), (string)TestContext.DataRow["Algorithm"]);
        Order order = (Order)Enum.Parse(typeof(Order), (string)TestContext.DataRow["Order"]);
        int seed = Int32.Parse((string)TestContext.DataRow["Seed"]);
        var array = SortHelper.CreateArray<int>(count, order, seed);
        Sorter<int> sorter = new Sorter<int>();
        sorter.Sort(array, algorithm);
        Assert.IsTrue(reflist.SequenceEqual(array));
    }
