    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(IEnumerable<InvoiceCategory> invoiceCategories)
    {
        if (ModelState.IsValid)
        {
            try
            {
                foreach(var invoiceCategory in invoiceCategories)
                {
                    if(invoiceCategory.InvoiceCategoryID == 0)
                    {
                        _context.InvoiceCategory.Add(invoiceCategory);    
                    }
                    else
                    {
                        _context.InvoiceCategory.Update(invoiceCategory);
                    }
                }
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
               ...
            }
        }
    }
