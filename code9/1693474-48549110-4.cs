    [HttpPost]
    public async Task<IActionResult> UnitTest([FromBody]MyDataR data) {
        var httpClient = new HttpClient();
        var requestJson = JsonConvert.SerializeObject(data);
        var url = "https://jsonplaceholder.typicode.com/posts";
        var response = await httpClient.PostAsync(url, new StringContent(requestJson, Encoding.UTF8, "application/json"));
        if(response.IsSuccessStatusCode) {
			var responseContent = await response.Content.ReadAsStringAsync();
			var responseModel = JsonConvert.DeserializeObject<MyModel>(responseContent);        
			return Ok(responseModel);
		}else 
			return StatusCode(response.StatusCode);
    }
