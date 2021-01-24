    var recipes = (from r in db.Recipies
                   join i in db.RecipeIngredient on r.Id equals i.RecipeId into Ingedients
                   join t in db.RecipeTag on r.Id equals t.RecipeId into Tags
                   orderby r.Name
                   select new
                   {
                       Name = r.Name,
                       Ingedients = Ingedients,
                       Tags = Tags
                   }).ToList()
                   .Select(x => new
                   {
                       Name = x.Name,
                       Ingredients = x.Ingedients
                           .Select(y => string.Format("{0} {1} {2}", y.Quantity, y.UOM, y.Name).Trim())
                           .Aggregate((c, n) => c + ", " + n),
                       Tags = x.Tags
                           .Select(y => y.Name)
                           .Aggregate((c, n) => c + ", " + n)
                   });
    return Json(recipes, JsonRequestBehavior = JsonRequestBehavior.AllowGet);
