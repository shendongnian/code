	void Main()
	{
		Categories = Load();
	
		var activate = new Func<CategoryModel, int, CategoryModel>((category, match)=>
		{
			if (category.Id == match)
				category.Active = true;
			return category;
		});
	
		Categories = Categories.Select(p => activate(p, 2));
		Categories.Dump();
	}
	
	public IEnumerable<CategoryModel> Categories { get; set; }
	
	public IEnumerable<CategoryModel> Load()
	{
		yield return new CategoryModel { Id=1, Name = "one" };
		yield return new CategoryModel { Id=2, Name = "two" };
		yield return new CategoryModel { Id=3, Name = "three" };
	}
	
	public class CategoryModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public bool Active { get; set; }
	}
    Id|Name|Active
    1 one False 
    2 two True 
    3 three False 
