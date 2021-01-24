    [HttpPost]
    [ActionName("mini")]
    public IActionResult GetMiniStatement([FromBody]Account account)
    {
        var miniState = BusinessLayer.Api.AccountHolderApi.GetMiniStatement(account.AccountNumber);
        return new ObjectResult(miniState.ToList());
    }
