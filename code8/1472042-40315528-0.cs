	var list = 
		JObject.Parse(json)
		.Descendants()
		.OfType<JProperty>()
		.Where(prop => prop.Value.HasValues)
		.Select(prop =>
		{
			
			var parentName = prop.Ancestors()
								 .OfType<JProperty>()
								 .Where(p => !(p.Value is JArray && ((JArray)p.Value).Count > 1))
								 .Select(p => p.Name)
								 .FirstOrDefault();
			var obj = new JObject(new JProperty("Current Property", prop.Name));
				
			obj.Add(new JProperty("Immediate Ancestor Property Name", parentName ?? ""));
			
			
			return obj;
		})
		.ToList();
