    public class Page
    {
        public Guid Id { get; set; }
        public Guid CustomerId { get; set; }
		[JsonProperty(ItemTypeNameHandling = TypeNameHandling.All)]
        public IList<Control> Controls { get; set; }
    }
