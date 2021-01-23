    [HttpGet("{id}")]
    public async Task<ActionResult> GetIic(int id)
    {
        // _context is a DB provider
        var Iic = await _context.Find(id).ConfigureAwait(false);
        if (Iic == null)
        {
            return NotFound();
        }
        var map = _mapper.Map<IicVM>(Iic);
        return Ok(map);
    }
