    public async Task<IActionResult> GetAll() {
        var response = await http.GetAsync("/Menu/GetAll");
        if (response.IsSuccessStatusCode) {
            var result = await response.Content.ReadAsAsync<List<Menu>>();
            return Ok(result);
        } else {
            return StatusCode((int)response.StatusCode);
        }
    }
