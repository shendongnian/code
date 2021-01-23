    [HttpPost]
    [Route("api/SampleData")]
    public async Task<IActionResult> CurrentForecasts(string location)
    {
        using (var client = new HttpClient())
        {
            client.BaseAddress = new Uri(" https://api.forecast.io/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            // HTTP GET
            HttpResponseMessage response = await client.GetAsync("forecast/APIKEY/"+location);
            if (response.IsSuccessStatusCode)
            {
                var forecast = await response.Content.ReadAsStringAsync();
                return Content(forecast, "application/json");
            }
        }
        return Json("Failed");
