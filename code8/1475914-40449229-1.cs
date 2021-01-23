        [HttpGet]
        public async Task<IActionResult> Create(string articleId)
        {
            Physics t = new Physics();
            if(!string.IsNullOrEmpty(articleId))
            {
                t.ArticleID = articleId;
            }
            return View(t);
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ID,CommentContext,UserName,ArticleID")]Physics physics)
        {
            if (ModelState.IsValid)
            {
                physics.UserName = HttpContext.User.Identity.Name;               
                //_context.Add(physics);
                //await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(physics);
        }
