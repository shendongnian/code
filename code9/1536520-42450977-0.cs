    var lb = new lineBuilder
	{
		col1_index_no = "item one",
		col2_depot_custRef = "item depot custRef"
        col10_RA_no = "further values will not make this explanation any clearer"
	};
		
	StringBuilder sb = new StringBuilder();
	IEnumerable<PropertyInfo> properties = typeof(lineBuilder)
												.GetProperties()
												.Where(p => p.PropertyType.Equals(typeof(string)))
												.OrderBy(p => p.Name);
		
	foreach(PropertyInfo propertyInfo in properties)
	{
		var value = (string)propertyInfo.GetValue(lb);	
		sb.AppendLine(string.Format("{0}: {1}", propertyInfo.Name, value ?? String.Empty));
	}
		
	Console.WriteLine(sb.ToString());
