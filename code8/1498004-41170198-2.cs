    public partial class ModalWindow : Window
    {
        private readonly WindowViewModel _viewModel;
        public ModalWindow()
        {
            InitializeComponent();
            _viewModel = new WindowViewModel();
            DataContext = _viewModel;
            Loaded += async (s, e) =>
            {
                _viewModel.InlaidViewModel = new InlaidViewModel();
                //wait 2 seconds before setting the MinHeight property
                await Task.Delay(2000);
                _viewModel.InlaidViewModel.MinHeight = 500;
            };
        }
    }
    public class WindowViewModel : INotifyPropertyChanged
    {
        private InlaidViewModel _inlaidViewModel;
        public InlaidViewModel InlaidViewModel
        {
            get { return  _inlaidViewModel; }
            set {  _inlaidViewModel = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    public class InlaidViewModel : INotifyPropertyChanged
    {
        private double _minHeight;
        public double MinHeight
        {
            get { return _minHeight; }
            set { _minHeight = value; NotifyPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
