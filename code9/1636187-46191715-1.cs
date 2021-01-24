    class AuxWindowViewModel : INotifyPropertyChanged
    {
        private readonly IClosableView view;
        // E.g. use a dependency injection via constructor
        public AuxWindowViewModel(IClosableView view)
        {
            this.view = view;
        }
        void CloseViewWithoutConfirmation()
        {
            this.view.Close(false);
        }
    }
