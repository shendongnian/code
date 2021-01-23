    private IEnumerable<System.Web.Mvc.SelectListItem> GetCategory()
    {
        var dbo = new WebEntities();
        var category = dbo
                        .bazar
                        .Select(x =>
                                new System.Web.Mvc.SelectListItem
                                {
                                    Value = x.ID.ToString(),
                                    Text = x.TITLE
                                });
         return category.ToList();
    }
