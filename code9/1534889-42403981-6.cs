    var personalesRowMaps = this.GetType().GetTypeInfo().GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
			.Where(f => f.Name.StartsWith("Personales_"))
            // f.Name.Split(...) part explained: each field has an underscore,
            // where the next character after it is the row index. Thus, 
            // I split the name using the underscore and I get the right part 
            // of the field identifier, and then I get the first character of
            // that part: the row index.
			.Select(f => new { Index = f.Name.Split('_')[1][0], Field = f })
			.GroupBy(o => o.Index)
			.Select(g => g.ToList().ToDictionary(o => o.Field.Name, o => o.Field.GetValue(this)));
