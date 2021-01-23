	var PTypeDictionary = new Dictionary<string, IList<PropertyType>>
	{
		["A"] = new List<PropertyType> { PropertyType.Apartment, PropertyType.Land, PropertyType.House},
		["B"] = new List<PropertyType> { PropertyType.Land, PropertyType.House},
		["C"] = new List<PropertyType> { PropertyType.Apartment, PropertyType.Land}
	};
	
	var empty = Properties.Where(x => 1==2);
	var props = PTypeDictionary.Aggregate(empty, (a, f) => a.Union(Properties.Where(p => p.Location == f.Key && f.Value.Contains(p.Type))));		
    var pList = props.ToList();
