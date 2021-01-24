	public class ViewModelProductCategory
	{
		public int Id { get; set; }
		public int? ParentId { get; set; }
		public string Title { get; set; }
		public int SortOrder { get; set; }
		public ViewModelProductCategory ParentCategory { get; set; }
		public IEnumerable<ViewModelProductCategory> Children { get; set; }
	}
