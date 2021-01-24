    public class MainViewModel : ViewModelBase
    {
        public SettingsPathSelectorViewModel FirstPath { get; } = new SettingsPathSelectorViewModel() { Label = "First Path" };
        public SettingsPathSelectorViewModel SecondPath { get; } = new SettingsPathSelectorViewModel() { Label = "Second Path" };
        public ObservableCollection<SettingsPathSelectorViewModel> SettingsPaths { get; } = new ObservableCollection<SettingsPathSelectorViewModel>
        {
            new SettingsPathSelectorViewModel() { Label = "First Collection Path" },
            new SettingsPathSelectorViewModel() { Label = "Second Collection Path" },
            new SettingsPathSelectorViewModel() { Label = "Third Collection Path" },
        };
    }
