    public class SomeOtherClass
    {
        private BrowseViewModelFactory _browseViewModelFactory;
        public SomeOtherClass(BrowseViewModelFactory browseViewModelFactory)
        {
            _browseViewModelFactory = browseViewModelFactory;
        }
        public void DoStuff()
        {
            var browseViewModel = _browseViewModelFactory.CreateBrowseViewModel(4321);
        }
    }
