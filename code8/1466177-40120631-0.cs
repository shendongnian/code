        public ActionResult Index()
        {
            var model = new TitlesViewModel();
            var titles = GetSelectListItems();
            model.Titles = titles;
            return View(model);
        }
        public IEnumerable<SelectListItem> GetSelectListItems()
        {
            foreach (var title in db.Titles)
            {
                yield return new SelectListItem
                {
                    Value = title.TitleId.ToString(),
                    Text = title.Title1
                };
            }
        }
