	public override void Run()
	{
		using (var context = new Microsoft.Xrm.Sdk.Client.OrganizationServiceContext(svc))
		{
			var result = (from e in context.CreateQuery("account").ToList()
							.Where(ne => isBetween(ne.GetAttributeValue<DateTime>("createdon"), DateTime.MinValue, DateTime.Now))
							select e).ToList();		
		}
	}
	private bool isBetween(DateTime value, DateTime min, DateTime max)
	{
		var val = (int)value.ToOADate();
		return val >= (int)min.ToOADate() || val <= (int)max.ToOADate();
	}
