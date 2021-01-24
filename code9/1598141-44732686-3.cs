     // GET: api/Users/abcde12345
    [HttpGet("{nameIdentifier:nameId}")]
    [Authorize]
    public async Task<IActionResult> GetUserByNameIdentifier([FromRoute] string nameIdentifier)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        User user = await _context.User.SingleOrDefaultAsync(m => m.NameIdentifier == nameIdentifier);
        if (user == null)
            return NotFound();
        return Ok(user);
    }
