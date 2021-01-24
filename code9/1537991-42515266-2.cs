        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EditInvoiceViewModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    model.invoice.creator = await GetCurrentUserAsync();
                    model.invoice.invoice_state = await _context.invoice_state.SingleOrDefaultAsync(m => m.ID == model.invoice_stateID);
                    _context.Update(model.invoice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!invoiceExists(model.invoice.ID))
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
