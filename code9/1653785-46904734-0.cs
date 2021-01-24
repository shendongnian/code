	[Authorize]
	// ..api/EmpDetails/Id
	public IEnumerable<EmpDetail> Get(string Id)
	{
		using (WebAPIEntities WE = new WebAPIEntities())
		{
			var emp = WE.TrxDetails.Where(E => E.EmpId == Id).ToList();
			return emp;
		}
	}
