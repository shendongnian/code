    [TestMethod()]
    public void ProductCSVfileReturnsResult() {
        var csvData = new string[] {
            "1,description1,Item,2.50,SomePath,BARCODE",
            "2,description2,Item,2.50,SomePath,BARCODE",
            "3,description3,Item,2.50,SomePath,BARCODE",
        };
        var mock = new Mock<IProductsCsvReader>();
        mock.Setup(_ => _.ReadAllLines(It.IsAny<string>())).Returns(csvData);
        ProductsCSV productCSV = new ProductsCSV(mock.Object);
        List<ProductItem> result = productCSV.GetAllProductsFromCSV();
        Assert.IsNotNull(result);
        Assert.AreEqual(csvData.Length, result.Count);
    }
