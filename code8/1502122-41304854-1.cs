    public async Task<IHttpActionResult> Get(string LabName) {
    
        using (var client_EndPoint = new HttpClient()) {
            //...other code removed for brevity
    
            var response_EndPoint = await client_EndPoint.GetAsync(EndPoint_URL);
            var models = await response_EndPoint.Content.ReadAsAsync<Model[]>();
            return Ok(models);
        }
    }
