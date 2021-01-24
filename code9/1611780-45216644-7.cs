    public class MyView
    {
        private readonly MyViewModel _viewModel;
        public MyView(MyViewModel viewModel)
              : base(viewModel)
        {
            InitializeComponent();
            _viewModel = viewModel;
            new MyViewModel().PropertyChanged +=OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MyViewModel.IsLoading))
            {
                if (_viewModel.IsLoading)
                {
                    Progress.StartAnimation();
                }
                else
                {
                    Progress.StopAnimation();
                }
            }
        }
    }
