        private static RegularViewModel _regularViewModel;
        public static RegularViewModel RegularViewModel
        {
            get
            {
                if (_regularViewModel == null)
                {
                    _regularViewModel = new RegularViewModel(MainViewModel);
                }
                return
                    _regularViewModel;
            }
            set { _regularViewModel = value; }
        }
        private static AdvancedViewModel _advancedViewModel;
        public static AdvancedViewModel AdvancedViewModel
        {
            get
            {
                if (_advancedViewModel == null)
                {
                    _advancedViewModel = new AdvancedViewModel(MainViewModel);
                }
                return
                    _advancedViewModel;
            }
            set { _advancedViewModel = value; }
        }
        private static MainViewModel _mainViewModel;
        public static MainViewModel MainViewModel
        {
            get
            {
                if (_mainViewModel == null)
                {
                    _mainViewModel = new MainViewModel();
                }
                return
                    _mainViewModel;
            }
            set { _mainViewModel = value; }
        }
    }
    public class MainViewModel : ViewModelBase, INaviagte
    {
       
        private ObservableCollection<ViewModelBase> viewModels;
        public ObservableCollection<ViewModelBase> ViewModels
        {
            get { return viewModels; }
            set { viewModels = value; }
        }
        private ViewModelBase selectedViewModel;
        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set { selectedViewModel = value; }
        }
        public MainViewModel()
        {
            ViewModels = new ObservableCollection<ViewModelBase>();
            ViewModels.Add(new RegularViewModel(this));
            ViewModels.Add(new AdvancedViewModel(this));
            SelectedViewModel = ViewModels[0];
        }
        private bool showCompactView;
        public bool ShowCompactView
        {
            get { return showCompactView; }
            set { showCompactView = value;RaisePropertyChanged("ShowCompactView"); }
        }
        
        public void Navigate(ViewModelBase _viewModel)
        {
            SelectedViewModel = _viewModel;
        }
    }
    public class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(v));
        }
    }
    public class RegularViewModel : ViewModelBase
    {
        INaviagte mainViewModel;
        public RegularViewModel(INaviagte _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
        public RegularViewModel()
        {
        }
        private void OnClick(object obj)
        {
            mainViewModel.Navigate(ViewModelLocator.AdvancedViewModel);
        }
    }
    public class AdvancedViewModel : ViewModelBase
    {
        INaviagte mainViewModel;
        public AdvancedViewModel(INaviagte _mainViewModel)
        {
            mainViewModel = _mainViewModel;
        }
        public AdvancedViewModel()
        {
        }
        private void OnClick(object obj)
        {
            mainViewModel.Navigate(ViewModelLocator.RegularViewModel);
        }
    }
    public interface INaviagte
    {
        void Navigate(ViewModelBase _viewModel);
    }
