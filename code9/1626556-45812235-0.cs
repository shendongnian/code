    public class Box {
    	[InverseProperty("IncomingBox")]
        public IList<BoxContentItem> IncomingBoxContentItems { get; set; }
    	
    	[InverseProperty("OutgoingBox")]
    	public IList<BoxContentItem> OutgoingBoxContentItems { get; set; }
    }
