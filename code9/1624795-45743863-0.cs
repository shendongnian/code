    [HttpPost, ActionName("EditUser")]
    [Authorize(Roles = Roles.Root + "," + Roles.Manager)]
    public async Task<IActionResult> Edit(string id, EditViewModel model, 
        string returnUrl = null)
    {
        if (ModelState.IsValid)
        {
    
            var studentToUpdate = await _dbContext.Users.SingleOrDefaultAsync(s => s.Id == id);
            if (studentToUpdate != null)
            {
                studentToUpdate.Surname = model.Surname;
                ... Other properties
    
                await _dbContext.SaveChangesAsync();
            }
            return Redirect(returnUrl);
        }
        return View(model);
    }
