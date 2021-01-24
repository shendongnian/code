	public IList<AccountBalanceModel> GetResult(DataTable dt)
	{
		var model = dt.AsEnumerable().Select(row => new AccountBalanceModel
					{
						Account = (string)row["ACCOUNT_ID"],
						Balance = (decimal)row["BALANCE"]
					}).ToList(); 
					
		return model;
	}
