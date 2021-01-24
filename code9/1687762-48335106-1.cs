    public JsonResult GetAllRecipes()
    {
        var recipes = db.Recipes
            .OrderBy(r => r.Name)
            .ToList() // this is necessary because we need Linq to Objects for the string formatting
            .Select(r => new // can be anonymous objects because we are returning a JsonResult
            {
                Id = r.Id,
                Name = r.Name,
                Ingredients = r.Ingredients
                    .Select(i => string.Format("{0} {1} {2}", i.Quantity, i.UOM, i.Name).TrimStart())
                    .Aggregate((c, n) => c + ", " + n),
                Tags = r.Tags
                    .Select(t => t.Name)
                    .Aggregate((c, n) => c + ", " + n)
            });
        return Json(recipes, JsonRequestBehavior = JsonRequestBehavior.AllowGet);
    }
