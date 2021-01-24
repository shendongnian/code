    public IActionResult CreateArticle()
    {
        var model = new Article { ArticleDate = DateTime.Now };
        return View(model);
    }
