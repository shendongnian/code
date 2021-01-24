    protected string url = "http://localhost:5001/api/Hospital";
    [HttpGet]
    public async Task<IActionResult> Edit(int id) {
        if (id.Equals(0))
            return StatusCode(404);
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        client.SetBearerToken(accessToken);
        HttpResponseMessage responseMessage = await client.GetAsync(url + "/GetById/" + id);
        if (responseMessage.IsSuccessStatusCode) {
            var responseData = await responseMessage.Content.ReadAsStringAsync();
            var hospital = JsonConvert.DeserializeObject<Hospital>(responseData);
            var hospitalVM = Mapper.Map<HospitalViewModel>(hospital);
            return View(hospitalVM);
        }
        return View("Error");
    }
