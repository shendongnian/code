        // GETAll api/category
        public IEnumerable<Category> GetAll()
        {
            nopMass db = new nopMass();
            var model = db.Categories.Where(x => x.ParentCategoryId == 0);
            Category[] cats = new Category[model.Count()];
            int index = 0;
            foreach (var cat in model)
            {
                cats[index] = new Category { ParentCategoryId = cat.ParentCategoryId, Name = cat.Name };
                index++;
            }
            return cats;
        }
