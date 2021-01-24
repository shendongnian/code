    [HttpGet("something")]
    public async Task<IActionResult> GetPerson(int id)
    {
        var result = await PeopleService.GetPersonByIdAsync(id);
        if (result != null)
            return Ok(result);
        else
            return NotFound("Role not found");
    }
