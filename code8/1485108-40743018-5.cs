    public class PlaceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var json = "[{\"placeId\": 1,\"placeName\": \"Malacca\"},{\"placeId\": 2,\"placeName\": \"Kuala Lumpur\"},{\"placeId\": 3,\"placeName\": \"Genting Highlands\"},{\"placeId\": 4,\"placeName\": \"Singapore\"},{\"placeId\": 5,\"placeName\": \"Penang\"},{\"placeId\": 6,\"placeName\": \"Perak\"},{\"placeId\": 8,\"placeName\": \"Selangor\"}]";
            var settings = new JsonSerializerSettings();
            settings.ContractResolver = new IncludeAllPropertiesContractResolver();
            var places = JsonConvert.DeserializeObject<Place[]>(json, settings);
            return Ok(places);
        }
    }
    public class IncludeAllPropertiesContractResolver : DefaultContractResolver
    {
        protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
        {
            IList<JsonProperty> properties = base.CreateProperties(type, memberSerialization);
            // Or other way to determine...
            foreach (var jsonProperty in properties)
            {
                // Include all properties.
                jsonProperty.Ignored = false;
            }
            return properties;
        }
    }
    [DataContract]
    public class Place
    {
        [JsonIgnore]
        [DataMember(EmitDefaultValue = false)]
        public int PlaceId { get; set; }
        [DataMember(EmitDefaultValue = false, Order = 1)]
        public string PlaceName { get; set; }
    }
