    private readonly IExternalService externalService; // Assumed injected into the controller
    [HttpPost]
    public async Task<IActionResult> UnitTest([FromBody]MyDataR data) {
        var responseModel = await externalService.PostDataAsync(data);
        if(responseModel != null) {
			return Ok(responseModel);
		}else 
			return BadRequest();
    }
	
