    [HttpGet("something")]
    public async Task<IActionResult> GetSomething(int somethingId)
    {
      var result = await _somethingService.GetSomethingAsync(somethingId);
      if (result != null)
        return Ok(result);
      else
        return NotFound("Role not found");
    }
