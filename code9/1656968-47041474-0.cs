        // POST: api/Recipients
        [HttpPost]
        public async Task<IActionResult> PostRecipient([FromBody] Recipient recipient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            _context.Recipients.Add(recipient);
            await _context.SaveChangesAsync();
            recipient = await _context.Recipients.Include(rec => rec.PrimaryContact).SingleOrDefaultAsync(m => m.Id == recipient.Id);
            return CreatedAtAction("GetRecipient", new { id = recipient.Id }, recipient);
        }
