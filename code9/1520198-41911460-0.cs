    public IEnumerable<TreeViewModel> BuildThree(IEnumerable<Category> categories, TreeViewModel parentCategory)
        {
            if (categories == null)
                return null;
            var result = new List<TreeViewModel>();
            foreach (var category in categories)
            {
               var treeViewModel = new TreeViewModel();
               treeViewModel.Id = category.CategoryId,
               treeViewModel.Text = category.CategoryName,
               treeViewModel.MyParent = parentCategory; 
               treeViewModel.Children= BuildThree(category.children,treeViewModel);
               result.Add(treeViewModel);   
            }
            return result;
        }
