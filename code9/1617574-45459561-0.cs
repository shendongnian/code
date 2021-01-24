    [HttpPost]
    public async Task<IActionResult> Post([FromBody]JObject value) {
        if (MesureController.CheckJsonIntegrity<Mesure>(value)) {
            var measure = await MesureAsync(value);
            return Ok(measure);
        }
        return BadRequest();
    }
