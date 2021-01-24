    public class REOProperty
    {
	    [InverseProperty("REOProperty")]
        public virtual ICollection<PropertyPhotoUrl> PropertyPhotoUrls { get; set; }
        public Guid REOPropertyId { get; set; }
    }
    public class PropertyPhotoUrl
    {
        public Guid REOPropertyId { get; set; }
		[ForeignKey("REOPropertyId")]
		[InverseProperty("PropertyPhotoUrls")]
        public virtual REOProperty REOProperty { get; set; }
        public Guid PropertyPhotoUrlId { get; set; }
        public string PhotoUrl { get; set; }
    }
