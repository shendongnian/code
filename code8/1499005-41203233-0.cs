	public class ConversionModel
	{
		[Required]//decimal would be better but up to you requirement
		public decimal ConversionRate { get; set; }
		[Required]
		public int FromCurrencyId {get;set;}
		public SelectList FromCurrencies {get;set;}
		
		[Required]
		public int ToCurrencyId {get;set;}
		public SelectList ToCurrencies {get;set;}
	}
 
