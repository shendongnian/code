	public static class Ex
	{
		public static List<Menu> CloneWhere(this List<Menu> source, Func<Menu, bool> predicate)
		{
			return
				source
					.Where(predicate)
					.Select(x => new Menu()
					{
						Name = x.Name,
						Link = x.Link,
						Children = x.Children.CloneWhere(predicate)
					})
					.Where(predicate)
					.ToList();
	    }
	}
