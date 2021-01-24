    public class ShellViewModel : BindableBase
    {
        private int _currentPage;
        public string Title => "Sample";
        public string DocumentPath => @"c:\temp\temp.xps";
        public int CurrentPage
        {
            get => _currentPage;
            set => SetProperty(ref _currentPage, value);
        }
        public ICommand PageChangedCommand => new DelegateCommand<int?>(i => CurrentPage = i.GetValueOrDefault());
    }
