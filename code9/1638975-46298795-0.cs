    [HttpPut]
    [Route("")]
    public async Task<IActionResult> Update([FromBody]ApiResourceUpdateDto dto) {
        await _repo.Update(dto.Name, dto.Enabled, dto.DisplayName, dto.Description);
        return new NoContentResult();
    }
