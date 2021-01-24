	public IEnumerable<Plan> GetPlans(int year)
	{
		return _context.Plans
			.Where(e => e.Excercise.Year == year)
			.ToList();
	}
