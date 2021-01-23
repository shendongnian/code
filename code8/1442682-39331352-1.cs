    public class ViewModel : INotifyPropertyChanged
    {
        public ViewModel()
        {
            BarItems = new[]
            {
                new Bar { Name = "Dog" },
                new Bar { Name = "Cat" },
                new Bar { Name = "Mouse" },
            };
        }
        public string SearchString
        {
            get { return searchString; }
            set
            {
                if (searchString != value)
                {
                    searchString = value;
                    SelectedBar = BarItems.FirstOrDefault(_ => !string.IsNullOrEmpty(_.Name) && _.Name.IndexOf(searchString, StringComparison.CurrentCultureIgnoreCase) >= 0);
                    OnPropertyChanged();
                }
            }
        }
        private string searchString;
        public Bar SelectedBar
        {
            get { return selectedBar; }
            set
            {
                if (selectedBar != value)
                {
                    selectedBar = value;
                    OnPropertyChanged();
                }
            }
        }
        private Bar selectedBar;
        public IEnumerable<Bar> BarItems { get; }
        // INPC implementation is omitted
    }
