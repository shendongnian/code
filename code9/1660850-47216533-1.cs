	var filterBuilder = Builders<yourObjectType>.Filter;
	var filters = new List<FilterDefinition<yourObjectType>>();
	filters.Add(filterBuilder.Eq(o => o.Country, paramsEntity.Country));
	if (!string.IsNullOrEmpty(paramsEntity.CompanyId))
	{
		filters.Add(filterBuilder.Eq(o => o.CompanyId, paramsEntity.CompanyId));
	}
	if (!string.IsNullOrEmpty(paramsEntity.StaffId))
	{
		filters.Add(filterBuilder.Eq(o => o.StaffId, paramsEntity.StaffId));
	}
	var dataCursor = collection.Find(filterBuilder.And(filters));
