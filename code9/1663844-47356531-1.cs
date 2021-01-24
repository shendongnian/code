    public async Task<IActionResult> Profiler(ProfilerViewModel model)
    {
        if (ModelState.IsValid)
        {
            var profile = new Profiler
            {
                FName = model.FName,
                Address = model.Address,
                BirthDate = model.BirthDate,
                PhoneNumber = model.PhoneNumber
                Comments = model.Comments
            };
            foreach (var file in model.Files)
            {
                // handle your file uploads
            }
 
            db.Profiles.Add(profile);
            await db.SaveChangesAsync();
            return RedirectToAction("Somewhere");
        }
        return View(model);
    }
