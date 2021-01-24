	public IList<AccountBalanceModel> GetResult(DataTable dt)
	{
		var model = from row in dt.AsEnumerable()
					select new AccountBalanceModel
					{
						Account = (string)row["ACCOUNT_ID"],
						Balance = (decimal)row["BALANCE"]
					}
					.ToList(); 
					
		return model;
	}
