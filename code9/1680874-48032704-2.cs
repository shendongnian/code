    var data = JsonConvert.DeserializeObject<List<SyncEntity>>(File.ReadAllText(@"E:\\JsonDemo.json"));
    data.ForEach(se =>
    {
        Console.WriteLine("The sync entity name is " + se.Name + ". And it has the following fields:");
        se.EntityFields.ForEach(ef =>
        {
            Console.WriteLine("{0} of type {1} with value {2}", ef.Name, ef.Type, ef.Value);
        });
    });
