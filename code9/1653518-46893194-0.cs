       // GET: SystemMenus/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_context.SystemMenus, "Id", "Name");      
            ViewData["Color"] = new SelectList(OptionDropdown.GetBackgroundColor(), "Value", "Text");
            ViewData["Size"] = new SelectList(OptionDropdown.GetSize(), "Value", "Text");
            ViewData["Module"] = new SelectList(OptionDropdown.GetModule(), "Value", "Text");
            return View();
        }
        // POST: SystemMenus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Controller,Action,ParentId,Icon,Module,Description,FixHeader,Color,Size")] SystemMenu systemMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(systemMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ParentId"] = new SelectList(_context.SystemMenus, "Id", "Name", systemMenu.ParentId);
            ViewData["Color"] = new SelectList(OptionDropdown.GetBackgroundColor(), "Value", "Text", systemMenu.Color);
            ViewData["Size"] = new SelectList(OptionDropdown.GetSize(), "Value", "Text", systemMenu.Size);
            ViewData["Module"] = new SelectList(OptionDropdown.GetModule(), "Value", "Text", systemMenu.Module);
            return View(systemMenu);
        }
