    public class VeryCoolViewModel : BaseViewModel, ITabViewModel
    {
        #region Properties
    
        public ObservableCollection<Test> Tests { get; set; }
        public Test currentSelection { get; set; }
        public string TabHeader { get; set; }
        
        public delegate void ChangeSelectedTab(string tabName)
        public event ChangeSelectedTab OnChangeSelectedTab
        #endregion
    
        #region Commands
    
        ICommand GoToOtherTab { get; set; }
    
        #endregion
    
        #region Constructor
    
        public GabaritSelecteurViewModel()
        {
            Tests = new ObservableCollection<Test>
            {
                new Test { Title = "Title #1" },
                new Test { Title = "Title #2" },
                new Test { Title = "Title #3" },
                new Test { Title = "Title #4" },
                new Test { Title = "Title #5" }
            };
    
            TabHeader = "Tests";
    
            GoToOtherTab = new RelayCommand(GoToTab, parameter => true);
        }
    
        private void GoToTab(object parameter)
        {
                OnChangeSelectedTab?.Invoke((string)parameter);
        }
    }
