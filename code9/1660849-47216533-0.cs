    var query = collection.AsQueryable().Where(e => e.Country == paramsEntity.Country);
	if (!string.IsNullOrEmpty(paramsEntity.CompanyId))
	{
		query = query.Where(e => e.CompanyId == paramsEntity.CompanyId);
	}
	if (!string.IsNullOrEmpty(paramsEntity.StaffId))
	{
		query = query.Where(e => e.StaffId == paramsEntity.StaffId);
	}
