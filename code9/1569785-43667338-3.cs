	[HttpPost]
	[ValidateAntiForgeryToken]
	public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ConcurrencyStamp")] MyEntity model)
	{
		if (id != model.Id)
		{
			return NotFound();
		}
		if (ModelState.IsValid)
		{
			try
			{
				_context.Update(model);
				await _context.SaveChangesAsync();
			}
			catch (DbUpdateConcurrencyException)
			{
				if (!MyEntityExists(model.Id))
				{
					return NotFound();
				}
				else
				{
					throw;
				}
			}
			return RedirectToAction("Index");
		}
		return View(model);
	}
