    public async Task<IActionResult> Edit(Client client_posted)
    {
      if (!ModelState.IsValid)
      {
    
        ModelState.AddModelError("", "Record is missing required values");
    
        // requery the client entity from our db to get related child entities
        var client_current = await _context.Client
                                            .Include(c => c.Office)
                                            // include 4 or 5 more entities here
                                            .Where(c => c.client_id == client_posted.client_id)
                                            .AsNoTracking()
                                            .SingleOrDefaultAsync();
    
        // now replace client_current values with client_posted values by
     
        // 1 - add entity to your db context (we are not saving it)
        _myDbContext.Client.Add(client_posted);
    
        // 2 - use the db context to extract current values from the client entity posted
        var client_posted_values =_myDbContext.Entry(client_posted).CurrentValues;
    
        // 3 - copy the extracted values to the client_current we re-queried from db
        _myDbContext.Entry(client_current).CurrentValues.SetValues(client_posted_values);
    
        // 4 return the view passing client with original values and the attached office entity(ies)
        return View(client_current);
      }
      // otherwise ModelState is valid, do the update here
      ...
      ...
    }
