	public enum PlanetColumn
	{
		Order = 0,
		Name = 1,
		Color = 2
	}
	string planets = "First Mercury Gray" 
                + Environment.NewLine 
                + "Second Venus Yellow"
                + Environment.NewLine
                + "Third Earth Blue"
                + Environment.NewLine 
                + "Fourth Mars Red"
                + Environment.NewLine;
	var lookup = planets
		.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries)
		.SelectMany(p => p.Trim().Split(' ').Select((value, colIndex) => new { Column = (PlanetColumn) colIndex, Value = value} ))
		.ToLookup(prop => prop.Column, prop => prop.Value);
	
	var planetOrders = lookup[PlanetColumn.Order].ToList();
	var planetNames = lookup[PlanetColumn.Name].ToList();
	var planetColors = lookup[PlanetColumn.Color].ToList();
