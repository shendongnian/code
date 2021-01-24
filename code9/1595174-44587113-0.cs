    private ObservableCollection<ViewRoleMapClass> _fullData; // replaces _viewList
    public ObservableCollection<ViewRoleMapClass> ViewList { get; private set; }
    private void searchByCriteria(string _viewName)
    {
        if (!string.IsNullOrEmpty(_viewName))
        {
            resultSearch = _fullData.Where(c => c.ViewCode.ToLower().Contains(_viewName.ToLower())).ToList();
            ViewList = new ObservableCollection<ViewRoleMapClass>(resultSearch);
        }
        else
            ViewList = _fullData;                                      
    }
