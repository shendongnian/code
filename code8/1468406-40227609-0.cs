        // POST: ListDefinitions/Edit/d1f82c08-58c5-4247-b43c-0a4f99ce2311
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id, Name,UserGuid")] ListDefinition listDefinition)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listDefinition);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListDefinitionExists(listDefinition.Id))
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
            return View(listDefinition);
        }
