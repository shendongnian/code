    public class MainViewModel : BaseViewModel
    {
        public override string Title
        {
            get
            {
                return "Main";
            }
        }
        private ObservableCollection<BaseViewModel> _viewModels;
        public ObservableCollection<BaseViewModel> ViewModels
        {
            get { return _viewModels; }
            set
            {
                if (value != _viewModels)
                {
                    _viewModels = value;
                    OnPropertyChanged();
                }
            }
        } 
        private BaseViewModel _currentViewModel;
        public BaseViewModel CurrentViewModel
        {
            get { return _currentViewModel; }
            set
            {
                if (value != _currentViewModel)
                {
                    _currentViewModel = value;
                    OnPropertyChanged();
                }                
            }
        }
        public MainViewModel()
        {
            ViewModels = new ObservableCollection<BaseViewModel>();
            ViewModels.Add(new NameViewModel());
            ViewModels.Add(new CodeViewModel());
            ViewModels.Add(new FactorDetailViewModel());
        }
    }
