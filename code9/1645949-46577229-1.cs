    var serializer = new JavaScriptSerializer();
    
    serializer.RegisterConverters(new[] {new RootObjectConverter()});
    
    var rootObject = new RootObject
    {
        items = new List<ItemObject>
        {
            new ItemObject { id = "567", url = "", title = "Pay with Prepaid Credit", desc = "Desc for paying for your order" },
            new ItemObject {id = "568", url = "", title = "Title Here", desc = "Description here"}
        }
    };
    
    string json = serializer.Serialize(rootObject);
    RootObject backToRootObject = serializer.Deserialize<RootObject>(json);
