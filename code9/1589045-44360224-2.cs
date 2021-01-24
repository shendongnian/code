    [Route("", Name = "GetAccount")]
    [HttpGet]
    public async Task<IHttpActionResult> GetAccount() {
        var query = Request.RequestUri.PathAndQuery.Split('/')[2]; //this query variable will be something "filter=name eq 'alex'"
        var response = await _accountService.Get(query);
        if (!response.IsSuccessStatusCode) {
            return NotFound();
        }
        var readAsAsync = response.Content.ReadAsAsync<object>();
        if (readAsAsync == null) {
            return NotFound();
        }
        var result = await readAsAsync;
        return Ok(result);
    }
