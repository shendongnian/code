    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel selectedViewModle;
        public BaseViewModel SelectedViewModel
        {
            get { return selectedViewModle; }
            set { selectedViewModle = value; OnPropertyChanged(nameof(SelectedViewModel)); }
        }
    }  
