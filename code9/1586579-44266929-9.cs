    private void categoryChanged()
    {
        if (SearchCriteria.CategoryID != 0)
        {
            Types = rr.GetCategoryTypes(SearchCriteria.CategoryID);
            SearchCriteria = new ResourceItem() {
                TypeId = 0,
                CategoryID = SearchCriteria.CategoryID
            };
            //  Do you need to do this?
            //  SearchCriteria.PropertyChanged += SearchCriteria_PropertyChanged;
        }
    }
