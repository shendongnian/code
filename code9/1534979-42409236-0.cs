    Console.WriteLine(JsonConvert.SerializeObject(
        System.Threading.Thread.CurrentThread,
        Formatting.Indented,
        new JsonSerializerSettings
        {
            ReferenceLoopHandling = ReferenceLoopHandling.Serialize
        }));
