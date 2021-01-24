            public List<CategoryViewModel> GetAllCategoriesAndTasksForParentCategoryAndUser(Guid? categoryId)
        {
            var data = new List<Category>();
            if (categoryId == null) // retrieve root level categories
            {
                    data = _ctx.Categories.Where(x => x.ParentCategoryId == null)
                        .Include(x => x.SubCategories)
                        .Include(x => x.Tasks)
                        .ToList();
            }
            else
            {
                    data = _ctx.Categories.Where(x => x.CategoryId == categoryId)
                        .Include(x => x.SubCategories)
                        .Include(x => x.Tasks)
                        .ToList();
            }
            var dataToReturn = Mapper.Map<List<Category>, List<CategoryViewModel>>(data);
            foreach (var category in data)
            {
                var vm = dataToReturn.First(x => x.CategoryId == category.CategoryId);
                //subCategories
                int totalCount = 0;
                SubCategoriesCount(ref totalCount, category);
                vm.TotalOfAllSubCategories = totalCount;            
            }
            return dataToReturn;
        }
