    public partial class NewSite
    {
        public string Id { get; set; }
        //[JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
        //[JsonProperty(PropertyName = "siteid")]
        public string SiteID { get; set; }
        //[JsonProperty(PropertyName = "address")]
        public string Address { get; set; }
        //[JsonProperty(PropertyName = "note")]
        public string Note { get; set; }
        //[JsonProperty(PropertyName = "icon")]
        public string Icon { get; set; }
        //[JsonProperty(PropertyName = "lat")]
        public double? Lat { get; set; }
        //[JsonProperty(PropertyName = "lng")]
        public double? Lng { get; set; }
    }
