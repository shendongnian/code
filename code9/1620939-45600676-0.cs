    public class SubCategory
    {
        [JsonIgnore]
        public DataTypes DataType { get; set; }
        [JsonIgnore]
        public string Parent { get; set; }
        [JsonProperty("ID")]
        public int Id { get; set; }
        [JsonProperty("categoryID")]
        public int CategoryId => Id;
        [JsonProperty("name")]
        public string Name { get; set; }
        public bool ShouldSerializeId()
        {
            return DataType == DataTypes.Id;
        }
        public bool ShouldSerializeCategoryId()
        {
            return DataType == DataTypes.CategoryId;
        }
    }
