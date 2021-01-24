    [NotifyPropertyChanged]
    public class MainViewModel : ViewModelBase
    {
        public MainViewModel()
        {
            CustomerCommand = new RelayCommand(GetCustomerView);
            //CurrentView = new CreateCustomerViewModel();
        }
        public ViewModelBase CurrentView { get; private set; }
        public RelayCommand CustomerCommand { get; set; }
    
        private void GetCustomerView()
        {
            CurrentView = new CreateCustomerViewModel();
        }
    }   // probably the ending '}' of the class --- added by editor!
