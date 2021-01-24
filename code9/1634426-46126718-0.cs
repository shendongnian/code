    public IEnumerable<YourItemWrapperViewModel> SelectedIndicies
    {
        get
        {
            return YourItemsCollection.Where(item => item.IsSelected);
        }
    }
