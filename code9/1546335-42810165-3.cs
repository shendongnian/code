    namespace YourNameSpace.View
    {
        public abstract class ViewBase<T> : UserControl
            where T : ViewModelBase
        {
            protected ViewModelBase ViewModel;
            public ViewBase(T viewModel)
                : base()
            {
                ViewModel = viewModel;
                DataContext = ViewModel;
            }
        }
    }
