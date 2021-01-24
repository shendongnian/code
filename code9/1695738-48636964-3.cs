    public class SettingsViewModel
    {
        public ObservableCollection<GeneralTabViewModel> Test { get; }
        public SettingsViewModel()
        {
            Test = new ObservableCollection<GeneralTabViewModel>
            {
                new GeneralTabViewModel { Name = "Tab 1" },
                new GeneralTabViewModel { Name = "Tab 2" }
            };
        }
    }
