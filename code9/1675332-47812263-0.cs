    public ViewResult Index(string sortOrder, string searchString, string[] FilteredsearchString, int time)
    {
        IQueryable recipes = db.Recipes.Include("Ingredients");
        if (!string.IsNullOrEmpty(searchString))
        {
            recipes = recipes.Where(r => r.Ingredients.Contains(searchString));
        }
        if (time == 30 || time == 60 || time == 61)
        {
            recipes = recieps.Where(c => c.Time <= time);
        }
        return View(recipes);
    }
