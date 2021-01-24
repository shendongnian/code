    string json = File.ReadAllText(@"sample.txt");
    List<DeskGopMapper> map = JObject.Parse(json)
        .Properties()
        .Select(p => new DeskGopMapper
        {
            DeskName = p.Name,
            GopName = p.Value.Children<JObject>()
                             .Select(j => (string)j["gopName"])
                             .ToList()
        })
        .ToList();
