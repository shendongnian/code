    static MediaTypeHeaderValue protoMediaType = MediaTypeHeaderValue.Parse("application/jsonfull");
    public JsonFullInputFormatter(ILogger logger, JsonSerializerSettings serializerSettings, ArrayPool<char> charPool, ObjectPoolProvider objectPoolProvider) 
        : base(logger, serializerSettings, charPool, objectPoolProvider)
    {
        this.SupportedMediaTypes.Clear();
        this.SupportedMediaTypes.Add(protoMediaType);
    }
    protected override JsonSerializer CreateJsonSerializer()
    {
        var serializer = base.CreateJsonSerializer();            
        serializer.ContractResolver = new NoJsonPropertyNameContractResolver();
        return serializer;
    }
