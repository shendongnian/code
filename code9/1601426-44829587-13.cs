    public class HomeViewModel : IPageViewModel // doesn't implement IPageDisplay
    {
        private IPageDisplay _pageDisplay;
        public HomeViewModel(IPageDisplay pageDisplay)
        {
            // HomeViewModel doesn't implement IPageDisplay, it *consumes* one
            // as a dependency (instead of the previous ApplicationViewModel).
            // Note, that the instance you're passing still is the ApplicationViewModel,
            // so not much has actually changed - but it means you can have another
            // implementation of IPageDisplay. You're only linking the classes together
            // by the functionality of displaying a page.
            _pageDisplay= pageDisplay;
        }
 
        public string Name
        {
            get
            {
                return "Home Page";
            }
        }
 
        private ICommand _loadDashboardCommand;
        public ICommand LoadDashboardCommand
        {
            get
            {
                if (_loadDashboardCommand == null)
                {
                    _loadDashboardCommand = new RelayCommand(
                        p => LoadOtherView());
                }
                return _loadDashboardCommand;
            }
        }
 
        private void LoadOtherView()
        {
            // Here you have the context of ApplicatiomViewModel like you required
            // but it can be replaced by any other implementation of IPageDisplay
            // as you're only linking the little bit of interface, not the whole class
 
            _pageDisplay.ChangeViewModel(new DashboardViewModel());
        }
    }
}
