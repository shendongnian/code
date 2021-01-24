    [HttpPost]
    [ActionName("mini")]
    public List<MiniStatement> GetMiniStatement(string accountNumber)
    {
    	var miniState = BusinessLayer.Api.AccountHolderApi.GetMiniStatement(accountNumber);
    	return miniState;
    }
