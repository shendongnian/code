	public class ProductCategoryVM
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public string Title { get; set; }
		public int? Products { get; set; }
		public IEnumerable<ProductCategoryVM> Children { get; set; }
	}
