	public string ConceptValues(string conceptOrder)
	{
		var split = conceptOrder.Split(new[] { "," }, StringSplitOptions.RemoveEmptyEntries);
		var nums = split.Select(s => Int32.Parse(s.Trim()));
		return nums.Select(n => ConceptValue(n))
			.Aggregate((acc, s) => string.Format("{0} {1}", acc, s));
	}
    public string ConceptValue(int concept)
    {
        switch (conceptOrder)
        {
            case 1:
                return Warehouse;
            case 2:
                return Commodity;
            // etc...
            default:
                throw new ArgumentException("Unhandled Concept", "concept");
        }
    }
