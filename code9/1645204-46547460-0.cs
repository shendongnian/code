    [HttpGet]
    public async Task<IActionResult> GetCustomersAsync() {
        var records = await _lodgingRepository.GetCustomersAsync();
        var model = await ConvertToDTO(records); //<-- perform convertions here
        return Ok(model);
    }
