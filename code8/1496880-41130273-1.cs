    Mock<IItem> mock=null;
    var items = new List<IItem>();
    mockCollection.Setup(x => x.AddNew()).Returns(() =>
    {
        mock = new Mock<IItem>();
        mockShipment.SetupAllProperties();
        return mock.Object;
    }).Callback(()=>
    {
        items.Add(mock.Object);
    });
