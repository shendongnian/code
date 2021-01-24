        [HttpGet]
        public ActionResult Index()
        {
            List<RecipeViewModel> recipes;
            List<Recipe> query;
            string index = string.Format("sitecore_{0}_index", Sitecore.Context.Database.Name);
            var sitecoreService = new SitecoreService(Sitecore.Context.Database.Name);
            string search = WebUtil.GetQueryString("search");
            //Search with Lucene
            using (var context = ContentSearchManager.GetIndex(index).CreateSearchContext())
            {
                if (!string.IsNullOrEmpty(search))
                {
                    query = context.GetQueryable<Recipe>().Where(p => p.Path.Contains("/sitecore/Content/Home/Recipes/")).Where(p => p.TemplateName == "Recipe").Where(p => p.RecipeName.Contains(search)).ToList();
                }
                else
                {
                    search = "";
                    query = context.GetQueryable<Recipe>().Where(p => p.Path.Contains("/sitecore/Content/Home/Recipes/")).Where(p => p.TemplateName == "Recipe").ToList();
                }
            }
            //Map to ViewModel
            recipes = query.Select(x => sitecoreService.GetItem<RecipeViewModel>(x.ItemId.Guid)).ToList();
            
            RecipesViewModel bvm = new RecipesViewModel() { Recipes = recipes, Search = search };
            return View(bvm);
        }
