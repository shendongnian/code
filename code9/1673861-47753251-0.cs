    Category _selectedCategory;
    public Category SelectedCategory
    {
        get
        {
            return _selectedCategory;
        }
        set
        {
            if (value != null)
            {
                PreviousSelectedCategory = value;
            }
            _selectedCategory = value;
            RaisePropertyChanged(nameof(SelectedCategory));
            CategorySelection();
        }
    }
