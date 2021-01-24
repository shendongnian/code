        public async Task<IActionResult> Edit(int? id)
        {
            
            var invoice = await _context.invoice
                .Include(_item => _item.invoice_state).SingleOrDefaultAsync(m => m.ID == id);
           
            string state = "start_finish"; // as a default
            var states = _context.invoice_state.Select(c => new { id = c.ID, title = c.title }).ToList();
            if (null != invoice.invoice_state)
            {
                ViewBag.State = invoice.invoice_state.alias;
            }
            else
            {
                ViewBag.State = state;
            }
            var vm = new EditInvoiceViewModel();
            vm.invoice = invoice;
            vm.States = _context
                                .invoice_state
                                .Select(c => new SelectListItem
                                {
                                    Value = c.ID.ToString(),
                                    Text = c.title
                                })
                                .ToList();
            if (null != invoice.invoice_state)
            {
                vm.invoice_stateID = invoice.invoice_state.ID;
            }  else {
                vm.invoice_stateID = _context.invoice_state.Where(e => e.alias == "start_finish").FirstOrDefault().ID;
            }
            return View(vm);
        }
