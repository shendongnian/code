    public CategoryModel Category
    {
        get { return category; }
        set 
        {
            category = value;
            // consider to use a lock here to avoid multi threading issues
            foreach(SelectListItem catItem in Categories)
               catItem.Selected = catItem.Value == value.Id.ToString();
        }
    }
