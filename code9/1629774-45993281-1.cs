    [HttpPut("{id}")]
    [ValidateModel]
    public async Task<IActionResult> UpdateAsync(
        [FromRoute] int id,
        [FromBody] ThingModel model)
