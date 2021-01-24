    public CallCenterPageResult<CallCenterCustomerSummary> GetCustomers(int page, int pageSize, IEnumerable<SortParameter> sortParameters, string keyword)
    {
    	using (var ctx = new EFCallCenterContext())
    	{
    		var customerDetails = ctx.CallCenterCustomers
    								 .Where(ccs => ccs.IsDeleted == false && (ccs.FirstName.Contains(keyword) || ccs.LastName.Contains(keyword) || ccs.Phone.Contains(keyword)))
    								 .OrderBy(o => o.Equals(sortParameters.ToOrderBy()))
    								 .Skip(pageSize * (page - 1)).Take(pageSize)
    								 .ToList();
    							 			
    		return customerDetails;
    	}
    }
