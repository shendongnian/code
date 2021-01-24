        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int companyId, [Bind("Color,CompanyId,ItemName,OrderNumb,Price,Qty,Size,Ordered")] Order order)
        {
            if (ModelState.IsValid)
            {
                _context.Add(order);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", new { CompanyId = order.CompanyId });
            }
            return View(order);
        }
