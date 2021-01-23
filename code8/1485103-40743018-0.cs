    public class PlaceController : ApiController
    {
        [HttpGet]
        public IHttpActionResult Get()
        {
            var foo = new Place()
            {
                PlaceId = 1,
                PlaceName = "foo"
            };
            return Ok(foo);
        }
    }
    [DataContract]
    public class Place
    {
       [DataMember(EmitDefaultValue = false)]
       [JsonIgnore]
       public int PlaceId { get; set; }
    
       [DataMember(EmitDefaultValue = false, Order = 1)]
       public string PlaceName { get; set; }
    }
