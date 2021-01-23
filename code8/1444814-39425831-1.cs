        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,ParentID")] Child child)
        {
            if (ModelState.IsValid)
            {
                int _id;
                do
                {
                    _id = new Random().Next();
                } while (await _context.Children.Where(b => b.ID == _id).AnyAsync());
                child.ID = _id;
                _context.Add(child);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ID"] = id;
            return View(child);
        }
