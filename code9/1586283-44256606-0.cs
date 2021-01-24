    [HttpPost]
    public async Task<IActionResult> CreateAddress([FromQuery] int client, [FromQuery] string name, [FromQuery] string email)
    {
        Address adr = new Address() { ClientId = client, Name = name, Email = email };
        _context.MailerAddresses.Add(adr);
        await _context.SaveChangesAsync();
        return Ok(adr);
    }
