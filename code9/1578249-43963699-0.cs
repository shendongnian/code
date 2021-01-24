    using(var database = new QDatabase("node-v6.10.3-x64.msi", DatabaseOpenMode.ReadOnly)) {
        var productVersion = database.Properties.AsEnumerable().FirstOrDefault(p => p.Property == "ProductVersion");
        if(productVersion != null)
            Console.WriteLine($"Product version is {productVersion.Value}");
    }
