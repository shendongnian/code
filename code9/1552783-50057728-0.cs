	var container = new Container(x => {
		x.Policies.SetAllProperties(
			policy => policy.Matching(				
				property => property.DeclaringType == typeof(Dependencies)
		);
	});
