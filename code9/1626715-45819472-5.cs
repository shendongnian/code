        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(ArticleViewModel articleViewModel) {
           (...)
           saveTheModel(articleViewModel.Article);
           (...)
        }
