    private void categoryChanged()
    {
        if (SearchCriteria.CategoryID != 0)
        {
            Types = rr.GetCategoryTypes(SearchCriteria.CategoryID);
            SearchCriteria.SelectedType = Types.FirstOrDefault();
            //SearchCriteria.TypeId = 0;
            //SearchCriteria = new ResourceItem() { TypeId = 0, CategoryID = SearchCriteria.CategoryID };
        }
    }
