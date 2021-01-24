    [HttpPost]
    [ActionName("mini")]
    public List<MiniStatement> GetMiniStatement([FromBody] MiniStatement state)
    {
    	var miniState = BusinessLayer.Api.AccountHolderApi.GetMiniStatement(state.AccountNumber);
    	return miniState;
    }
