    class MyView
    {
        private readonly MyViewModel _viewModel;
        public MyView(MyViewModel viewModel)
        {
            _viewModel = viewModel;
            new MyViewModel().PropertyChanged +=OnPropertyChanged;
        }
        private void OnPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == nameof(MyViewModel.IsLoading))
            {
                if (_viewModel.IsLoading)
                {
                    //Start Loading Animation
                }
                else
                {
                    //Stop Loading Animation
                }
            }
        }
    }
