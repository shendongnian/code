    [HttpPost]
            [ResponseType(typeof(TerminalPersonnelEmail))]        
            public async Task<IHttpActionResult> Post(TerminalPersonnelEmail email)
            {
    
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }
    
                if (email == null)
                {
                    throw new ArgumentException("The data entry given is invalid");
                }
                    
                
                portalDatabaseContext.TerminalPersonnelEmails.Add(email);
                await portalDatabaseContext.SaveChangesAsync();
                return Created(email);
