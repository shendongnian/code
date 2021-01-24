        private void SubCategoriesCount(ref int subCatCount, Category category)
        {
            if (category.SubCategories != null || category.SubCategories.Count() != 0)
            {
                subCatCount += category.SubCategories.Count();
                foreach (var subCat in category.SubCategories)
                {
                    SubCategoriesCount(ref subCatCount, subCat);
                }
            }
        }
