    public class PropertyForSale
    {
		[Key]
		public int Id { get; set; }
		[Index("IX_pid", IsClustered = false, IsUnique = true, Order = 1), MaxLength(128)]
		public string pid { get; set; }
		public string Test { get; set; }
		public int PropertyForSale_PredictionsId {get;set;}
		public PropertyForSale_Predictions PropertyForSale_Predictions { get; set; }
		
		public int PropertyForSale_RatiosId {get; set;}
		public PropertyForSale_Ratios PropertyForSale_Ratios { get; set; }
    }
	
    public class PropertyForSale_Predictions
    {
		[Key, MaxLength(128)]
		public string pid { get; set; }
		public string Test { get; set; }
    }
    public class PropertyForSale_Ratios
    {
		[Key, MaxLength(128)]
		public string pid { get; set; }
		public string Test { get; set; }
    }
