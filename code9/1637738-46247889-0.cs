            [HttpPost]
            [ValidateAntiForgeryToken]
            public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Description,ParentId,Timestamp")] ItemStatus itemStatus)
            {
                if (id != itemStatus.Id)
                    return NotFound();
                
                if (ModelState.IsValid)
                {
                    try
                    {
                        _context.Update(itemStatus);
                        await _context.SaveChangesAsync();
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!ItemStatusExists(itemStatus.Id))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                    return RedirectToAction(nameof(Index));
                }
    
                ViewData["ParentId"] = new SelectList(_context.ItemStatus, "Id", "Description", itemStatus.ParentId);
                return View(itemStatus);
            }
