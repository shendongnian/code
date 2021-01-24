    _model = new HomeViewModel()
             {
                 Categories = _context.Categories.Select(x => x.ToCategories()).ToList(),
                 QuestionModel = new List<QuestionModel>()
             };
    Session["model"] = _model;
