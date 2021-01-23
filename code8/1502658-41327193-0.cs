    Product product = new Product();
    product.Name = "Apple";
    product.Expiry = new DateTime(2008, 12, 28);
    product.Sizes = new string[] { "Small" };
    
    // serialize JSON to a string
    string json = JsonConvert.SerializeObject(product);
    
    // write string to a file
    var file = await ApplicationData.Current.LocalFolder.CreateFileAsync("myconfig.json");
    await FileIO.WriteTextAsync(file, json);
