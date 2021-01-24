	[Authorize]
	// ..api/EmpDetails/Id
	public IEnumerable<EmpDetail> Get(string Id)
	{
		using (WebAPIEntities WE = new WebAPIEntities())
		{
			return WE.TrxDetails.FirstOrDefault(E => E.EmpId == Id);
		}
	}
