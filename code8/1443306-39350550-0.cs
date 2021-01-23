	public static IEnumerable<SelectListItem> GetAllMerits()
	{
		using (DataContext ctx = new DataContext())
		{
			var results = (from m in ctx.MeritBadges
						   select new SelectListItem
						   {
							   Value = m.ID.ToString(),
							   Text = m.MeritBadgeName
						   }
						   ).OrderBy(o => o.Text).ToArray(); // .ToArray() => materialize collection. After this data will be returned from database.
	
			return new SelectList(results, "Value", "Text"); 
		}
	}
