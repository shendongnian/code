    public class MainViewModel
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
            ViewModels.Add(new RegularViewModel());
            ViewModels.Add(new AdvancedViewModel());
            SelectedViewModel = ViewModels[0];
        }
    }
    public class ViewModelBase
    {
    }
    public class RegularViewModel : ViewModelBase
    {
    }
    public class AdvancedViewModel : ViewModelBase
    {
    }
