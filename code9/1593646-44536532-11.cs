    private ItemToModelMapper mapper;
    void Start()
    {
        Item item = new Item();
        ...
        ...
        // Serialize
        var serializationModel = this.mapper.MapToModel(item);
        string json = JsonUtility.ToJson(serializationModel );
        // Deserialize
        SerializableItemModel deserializedModel = JsonUtility.FromJson<SerializableItemModel>(json);
        Item loadedItem = this.mapper.MapFromModel(deserializedModel);
    }
