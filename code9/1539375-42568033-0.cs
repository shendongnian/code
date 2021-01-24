    const string ESServer = "http://localhost:9200";
    ConnectionSettings settings = new ConnectionSettings(new Uri(ESServer))
        .DefaultIndex("tiky");
        .MapDefaultTypeNames(map => map.Add(typeof(DAL.Faq), "faq"))
        // pass POCO property names through verbatim
        .DefaultFieldNameInferrer(s => s);
    ElasticClient client = new ElasticClient(settings);
