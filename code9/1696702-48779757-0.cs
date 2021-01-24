    public ActionResult Index()
    {
        var userId = User.Identity.GetUserId();
        var recipes = db.Categories.Where(u => u.Users.Any(x => x.Id == userId))
                            .Include(c => c.Category1)
                            .Include(r => r.Recipes
                                .Select(u => u.UserRecipes
                                    .Select(s => s.MeasUnitSystem.MeasUnitConv)))
                            .Include(r => r.Recipes
                                .Select(u => u.UserRecipes
                                    .Select(s => s.MeasUnitSystem.MeasUnit.MeasUnitSymbols)));
        IEnumerable<CategoryRecipeIndexViewModel> recipesVM = Mapper.Map<IEnumerable<Category>, IEnumerable<CategoryRecipeIndexViewModel>>(recipes.ToList());
        return View(recipesVM);
    }
