	public static class Ex
	{
		public static List<Menu> CloneWhere(this List<Menu> source, Func<Menu, bool> predicate)
		{
			return
				source
					.Where(predicate)
					.Select(x =>
					{
						var menu = new Menu() { Name = x.Name, Link = x.Link };
						menu.Children.AddRange(x.Children.CloneWhere(predicate));
						return menu;
					})
					.ToList();
	    }
	}
