    public string SearchString
    {
        get { return _searchString; }
        set
        {
            if (_searchString != value)
            {
                _searchString = value;
                var navigationParams = new NavigationParameters {{ "searchString", _searchString }};
                _regionManager.RequestNavigate(RegionNames.ContentRegion, "SearchResultsView", navigationParams);
                OnPropertyChanged();
            }
        }
    }
    // --------------------------------------------------------------------
    public class SearchResultsViewModel : BindableBase, INavigationAware
    {
        private string _searchString;
        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            _searchString = navigationContext.Parameters["searchString"] as string;
        }
        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            var searchString = navigationContext.Parameters["searchString"] as string;
            return _searchString.Equals(searchString);
        }
        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            // Ignored
        }
    }
