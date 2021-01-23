    public ActionResult BazarInsert()
            {
                var model = new BazarInsertViewModel
                {
                    MyCategory = GetCategory()
                };
                return View(model);
            }
            private SelectList GetCategory()
            {
                var dbo = new WebEntities();
                var category = dbo
                            .bazar
                            .Select(x =>
                                    new Models.HomeViewModels.SelectListItem
                                    {
                                        Value = x.ID.ToString(),
                                        Text = x.TITLE
                                    });
    
                return new SelectList(category, "Value", "Text");
            }
            
