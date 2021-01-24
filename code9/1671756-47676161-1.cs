    class MainWorkspaceViewModel : INotifyPropertyChanged
    {
        private object _view;
        public object View {
            get { return _view; }
            set { _view = value; OnPropertyChanged(); }
        }
        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
    internal class MyViewManager
    {
        internal static MainWorkspaceView MakeMainView()
        {
            var view = new MainWorkspaceView();
            view.DataContext = new MainWorkspaceViewModel();
            return view;
        }
        internal static void UpdateView(MainWorkspaceViewModel viewmodel, object _next)
        {
            viewmodel.View = _next;
        }
        internal static void UpdateView(MainWorkspaceView view, object _next)
        {
            (view.DataContext as MainWorkspaceViewModel).View = _next;
        }
    }
