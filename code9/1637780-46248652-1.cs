	public void AddItems(QueryFilterOptions options = null) {
		using (_db)
		{
			if (options == null) {
				options = new QueryFilterOptions();
			}
			
			var items = _db.BM_OPT_MASTER; 
			
			items = FilterOnCompanyID(items, options.CompanyID);
			items = FilterOnHealthPlanCode(items, options.HealthplanCode);
			items = FilterOnSomeOtherQueryOption(items, options.SomeOtherQueryOption);
			//...other filters
			
			items = items.Select(y => y.OPT).Distinct();
			
			foreach (var item in items) 
            {
				currentComboBox.Items.Add(item);
			}
		}
	}
	
	private IQueryable<BM_OPT_MASTER> FilterOnCompanyID(IQueryable<BM_OPT_MASTER> items, string companyID)
	{
		if (!(string.IsNullOrEmpty(companyID)))
		{
			items = items.Where(y => y.COMPANY_ID == companyID);
		}
		
		return items;
	}
	
	private IQueryable<BM_OPT_MASTER> FilterOnHealthPlanCode(IQueryable<BM_OPT_MASTER> items, string healthplanCode)
	{
		if (!(string.IsNullOrEmpty(healthplanCode)))
		{
			items = items.Where(y => y.HPCODE == healthplanCode);
		}
		
		return items;
	}
	
	private IQueryable<BM_OPT_MASTER> FilterOnSomeOtherQueryOption(IQueryable<BM_OPT_MASTER> items, string someOtherQueryOption)
	{
		if (!(string.IsNullOrEmpty(someOtherQueryOption)))
		{
			items = items.Where(y => y.SOME_OTHER_QUERY_OPTION == someOtherQueryOption);
		}
		
		return items;		
	}
